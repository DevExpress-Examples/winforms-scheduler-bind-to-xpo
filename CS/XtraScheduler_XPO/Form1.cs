using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.Xpo;

namespace XtraScheduler_XPO {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            PrepareScheduler();
            PrepareXpCollections();

            EnsureDbConnection();
            
            schedulerStorage1.Appointments.DataSource = this.xpCollection1;
            schedulerStorage1.Resources.DataSource = this.xpCollection2;
            
            FillData();
        }

        void PrepareScheduler() {
            this.schedulerControl1.Start = DateTime.Today;
            this.schedulerControl1.GroupType = SchedulerGroupType.Resource;

            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "Finish";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder";
            this.schedulerStorage1.Appointments.Mappings.Start = "Start";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "AppointmentType";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId";

            this.schedulerStorage1.Resources.Mappings.Id = "ResourceId";
            this.schedulerStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";

            this.schedulerStorage1.ResourcesDeleted += OnResourcesChanged;
            this.schedulerStorage1.AppointmentsChanged += OnAppointmentsChanged;
            this.schedulerStorage1.ResourcesChanged += OnResourcesChanged;
            this.schedulerStorage1.ResourcesInserted += OnResourcesChanged;
            this.schedulerStorage1.AppointmentsInserted += OnAppointmentsChanged;
            this.schedulerStorage1.AppointmentsDeleted += OnAppointmentsChanged;
        }
        void PrepareXpCollections() {
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            
            this.xpCollection1.DeleteObjectOnRemove = true;
            this.xpCollection1.DisplayableProperties = "This;Oid;AllDay;Description;Finish;Label;Location;Recurrence;Reminder;Start;Statu" +
                "s;Subject;AppointmentType;ResourceId";
            this.xpCollection1.ObjectType = typeof(XtraScheduler_XPO.Task);

            this.xpCollection2.DeleteObjectOnRemove = true;
            this.xpCollection2.DisplayableProperties = "Name;ResourceId;Color";
            this.xpCollection2.ObjectType = typeof(XtraScheduler_XPO.XPResource);

            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection2)).EndInit();
        }
        void FillData() {
            if (this.schedulerStorage1.Resources.Count == 0) {
                Resource res1 = this.schedulerStorage1.CreateResource(1);
                res1.Caption = "First Resource";
                res1.Color = Color.LightSkyBlue;
                this.schedulerStorage1.Resources.Add(res1);
                Resource res2 = this.schedulerStorage1.CreateResource(2);
                res2.Caption = "Next Resource";
                res2.Color = Color.LightYellow;
                this.schedulerStorage1.Resources.Add(res2);
            }

            if (this.schedulerStorage1.Appointments.Count == 0) {
                Appointment apt1 = this.schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                apt1.Start = DateTime.Now;
                apt1.End = apt1.Start.AddHours(2.5f);
                apt1.Subject = "First Appointment";
                apt1.LabelId = 1;
                apt1.ResourceId = this.schedulerStorage1.Resources[0].Id;
                this.schedulerStorage1.Appointments.Add(apt1);
            }

        }
        void OnAppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject((SchedulerStorage)sender) as XPBaseObject;
                if (o != null) 
                    o.Save();
            }
        }
        void OnResourcesChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Resource res in e.Objects) {
                XPBaseObject o = res.GetSourceObject((SchedulerStorage)sender) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }
        void EnsureDbConnection() {
            try {
                this.xpCollection1.Session.Connect();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Can't connect to database");
            }
        }
    }
}
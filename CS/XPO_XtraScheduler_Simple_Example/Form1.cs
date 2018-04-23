using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XPO_XtraScheduler_Simple_Example {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            session1.ConnectionString = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("XPO_XtraScheduler_Simple_Example.mdb");

            schedulerStorage1.Appointments.DataSource = xpAppointmentCollection;
            schedulerStorage1.Resources.DataSource = xpResourceCollection;

            CreateMappings();
            InitData();

            schedulerStorage1.AppointmentsChanged += OnAppointmentsChanged;
            schedulerStorage1.AppointmentsInserted += OnAppointmentsChanged;

            schedulerStorage1.Appointments.ResourceSharing = false;
            schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.Views.DayView.TopRowTime = DateTime.Now.TimeOfDay;

        }

        private void InitData() {
            if (xpResourceCollection.Count == 0) {
                Resource res1 = schedulerStorage1.CreateResource(1);
                res1.Caption = "First Resource";
                res1.Color = Color.LightSkyBlue;
                schedulerStorage1.Resources.Add(res1);
                Resource res2 = schedulerStorage1.CreateResource(2);
                res2.Caption = "Next Resource";
                res2.Color = Color.LightYellow;
                schedulerStorage1.Resources.Add(res2);
                session1.Save(xpResourceCollection);
            }

            if (schedulerStorage1.Appointments.Count == 0) {
                Appointment apt1 = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                apt1.Start = DateTime.Now;
                apt1.End = apt1.Start.AddHours(2.5f);
                apt1.Subject = "First Appointment";
                apt1.LabelId = 1;
                apt1.ResourceId = schedulerStorage1.Resources[0].Id;
                schedulerStorage1.Appointments.Add(apt1);
                session1.Save(xpAppointmentCollection);
            }
        }

        private void CreateMappings() {
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "Finish";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "Resource!Key";
            this.schedulerStorage1.Appointments.Mappings.Start = "Created";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "AppointmentType";

            this.schedulerStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "Oid";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
        }

        void OnAppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject((SchedulerStorage)sender) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }
    }
}

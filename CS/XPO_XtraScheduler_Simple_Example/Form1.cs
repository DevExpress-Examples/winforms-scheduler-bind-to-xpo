using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using System;
using System.Windows.Forms;

namespace XPO_XtraScheduler_Simple_Example {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            session1.ConnectionString = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("XPO_XtraScheduler_Simple_Example.mdb");

            schedulerDataStorage1.Appointments.DataSource = xpAppointmentCollection;
            schedulerDataStorage1.Resources.DataSource = xpResourceCollection;

            CreateMappings();
            InitData();

            schedulerDataStorage1.AppointmentsChanged += OnAppointmentsChanged;
            schedulerDataStorage1.AppointmentsInserted += OnAppointmentsChanged;
                        
            schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.Views.DayView.TopRowTime = DateTime.Now.TimeOfDay;
        }

        private void InitData() {
            if (xpResourceCollection.Count == 0) {
                Resource res1 = schedulerDataStorage1.CreateResource(1);
                res1.Caption = "First Resource";
                res1.ColorValue = "LightSkyBlue";
                schedulerDataStorage1.Resources.Add(res1);
                Resource res2 = schedulerDataStorage1.CreateResource(2);
                res2.Caption = "Next Resource";
                res2.ColorValue = "LightYellow";
                schedulerDataStorage1.Resources.Add(res2);
                session1.Save(xpResourceCollection);
            }

            if (schedulerDataStorage1.Appointments.Count == 0) {
                Appointment apt1 = schedulerDataStorage1.CreateAppointment(AppointmentType.Normal);
                apt1.Start = DateTime.Now;
                apt1.End = apt1.Start.AddHours(2.5f);
                apt1.Subject = "First Appointment";
                apt1.LabelKey = 1;
                apt1.ResourceId = schedulerDataStorage1.Resources[0].Id;
                schedulerDataStorage1.Appointments.Add(apt1);
                session1.Save(xpAppointmentCollection);
            }
        }

        private void CreateMappings() {
            this.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerDataStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerDataStorage1.Appointments.Mappings.End = "Finish";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerDataStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence";
            this.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "Reminder";
            this.schedulerDataStorage1.Appointments.Mappings.ResourceId = "Resource!Key";
            this.schedulerDataStorage1.Appointments.Mappings.Start = "Created";
            this.schedulerDataStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerDataStorage1.Appointments.Mappings.Type = "AppointmentType";

            this.schedulerDataStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerDataStorage1.Resources.Mappings.Color = "Color";
            this.schedulerDataStorage1.Resources.Mappings.Id = "Oid";
            this.schedulerDataStorage1.Resources.Mappings.Image = "Image";
        }

        void OnAppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject((SchedulerDataStorage)sender) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }
    }
}

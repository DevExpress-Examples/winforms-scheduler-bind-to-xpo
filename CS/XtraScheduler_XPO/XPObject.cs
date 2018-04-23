using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Xpo;

namespace XtraScheduler_XPO {
    // XP object
    public class Task : XPObject {
        public Task(Session session) : base(session) { }

        // Appointment.AllDay
        bool _allDay;
        public bool AllDay {
            get { return _allDay; }
            set { SetPropertyValue("AllDay", ref _allDay, value); }
        }

        // Appointment.Description
        string _description;
        [Size(SizeAttribute.Unlimited)]
        public string Description {
            get { return _description; }
            set { SetPropertyValue("Description", ref _description, value); }
        }

        // Appointment.End
        DateTime _finish;
        public DateTime Finish {
            get { return _finish; }
            set { SetPropertyValue("Finish", ref _finish, value); }
        }

        // Appointment.Label
        int _label;
        public int Label {
            get { return _label; }
            set { SetPropertyValue("Label", ref _label, value); }
        }

        // Appointment.Location
        string _location;
        public string Location {
            get { return _location; }
            set { SetPropertyValue("Location", ref _location, value); }
        }

        // Appointment.RecurrenceInfo
        string _recurrence;
        [Size(SizeAttribute.Unlimited)]
        public string Recurrence {
            get { return _recurrence; }
            set { SetPropertyValue("Recurrence", ref _recurrence, value); }
        }

        // Appointment.ReminderInfo
        string _reminder;
        [Size(SizeAttribute.Unlimited)]
        public string Reminder {
            get { return _reminder; }
            set { SetPropertyValue("Reminder", ref _reminder, value); }
        }

        // Appointment.Start
        DateTime _start;
        public DateTime Start {
            get { return _start; }
            set { SetPropertyValue("Start", ref _start, value); }
        }

        // Appointment.Status
        int _status;
        public int Status {
            get { return _status; }
            set { SetPropertyValue("Status", ref _status, value); }
        }

        // Appointment.Subject
        string _subject;
        public string Subject {
            get { return _subject; }
            set { SetPropertyValue("Subject", ref _subject, value); }
        }

        // Appointment.Type
        int _appointmentType;
        public int AppointmentType {
            get { return _appointmentType; }
            set { SetPropertyValue("AppointmentType", ref _appointmentType, value); }
        }

        // Appointment.ResourceId
        int _resourceId;
        public int ResourceId
        {
            get { return _resourceId; }
            set { SetPropertyValue("ResourceId", ref _resourceId, value); }
        }


            [Association()]
        public XPCollection<XPResource> Resources
        {
            get
            {
                return GetCollection<XPResource>("Resources");
            }
        }
    }

    // XP object
    public class XPResource : XPObject
    {
        public XPResource(Session session) : base(session) { }

        // Resource identifier
        int _resourceId;
        public int ResourceId
        {
            get { return _resourceId; }
            set { SetPropertyValue("ResourceId", ref _resourceId, value); }
        }

        // Resource identifier
        string _name;
        public string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }

        int _color;
        public int Color
        {
            get { return _color;}
            set { SetPropertyValue("Color", ref _color, value); }
        }

        [Association()]
        public XPCollection<Task> Tasks
        {
            get
            {
                return GetCollection<Task>("Tasks");
            }
        }
    }



}
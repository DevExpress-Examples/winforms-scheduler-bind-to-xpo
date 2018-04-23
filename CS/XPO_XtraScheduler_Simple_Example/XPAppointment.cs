using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Xml;
using System;

namespace XPO_XtraScheduler_Simple_Example {
    #region #xpappointment
    // XP object
    public class XPAppointment : XPObject {
        public XPAppointment(Session session) : base(session) { }

        public bool AllDay;              // Appointment.AllDay

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Description;       // Appointment.Description

        public DateTime Finish;          // Appointment.End
        public int Label;                // Appointment.Label
        public string Location;          // Appointment.Location

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Recurrence;        // Appointment.RecurrenceInfo

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Reminder;          // Appointment.ReminderInfo

        public DateTime Created;         // Appointment.Start
        public int Status;               // Appointment.Status
        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Subject;           // Appointment.Subject
        public int AppointmentType;      // Appointment.Type
        public XPResource Resource;
    }
    #endregion #xpappointment
}
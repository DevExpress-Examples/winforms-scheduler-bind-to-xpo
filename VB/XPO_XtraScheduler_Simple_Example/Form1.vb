Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler
Imports System.Drawing
Imports System.Windows.Forms

Namespace XPO_XtraScheduler_Simple_Example

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            session1.ConnectionString = DB.AccessConnectionProvider.GetConnectionString("XPO_XtraScheduler_Simple_Example.mdb")
            schedulerStorage1.Appointments.DataSource = xpAppointmentCollection
            schedulerStorage1.Resources.DataSource = xpResourceCollection
            CreateMappings()
            InitData()
            AddHandler schedulerStorage1.AppointmentsChanged, AddressOf OnAppointmentsChanged
            AddHandler schedulerStorage1.AppointmentsInserted, AddressOf OnAppointmentsChanged
            schedulerStorage1.Appointments.ResourceSharing = False
            schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource
            schedulerControl1.Views.DayView.TopRowTime = Date.Now.TimeOfDay
        End Sub

        Private Sub InitData()
            If xpResourceCollection.Count = 0 Then
                Dim res1 As Resource = schedulerStorage1.CreateResource(1)
                res1.Caption = "First Resource"
                res1.Color = Color.LightSkyBlue
                schedulerStorage1.Resources.Add(res1)
                Dim res2 As Resource = schedulerStorage1.CreateResource(2)
                res2.Caption = "Next Resource"
                res2.Color = Color.LightYellow
                schedulerStorage1.Resources.Add(res2)
                session1.Save(xpResourceCollection)
            End If

            If schedulerStorage1.Appointments.Count = 0 Then
                Dim apt1 As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
                apt1.Start = Date.Now
                apt1.End = apt1.Start.AddHours(2.5F)
                apt1.Subject = "First Appointment"
                apt1.LabelId = 1
                apt1.ResourceId = schedulerStorage1.Resources(0).Id
                schedulerStorage1.Appointments.Add(apt1)
                session1.Save(xpAppointmentCollection)
            End If
        End Sub

        Private Sub CreateMappings()
            schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            schedulerStorage1.Appointments.Mappings.Description = "Description"
            schedulerStorage1.Appointments.Mappings.End = "Finish"
            schedulerStorage1.Appointments.Mappings.Label = "Label"
            schedulerStorage1.Appointments.Mappings.Location = "Location"
            schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
            schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
            schedulerStorage1.Appointments.Mappings.ResourceId = "Resource!Key"
            schedulerStorage1.Appointments.Mappings.Start = "Created"
            schedulerStorage1.Appointments.Mappings.Status = "Status"
            schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            schedulerStorage1.Appointments.Mappings.Type = "AppointmentType"
            schedulerStorage1.Resources.Mappings.Caption = "Name"
            schedulerStorage1.Resources.Mappings.Color = "Color"
            schedulerStorage1.Resources.Mappings.Id = "Oid"
            schedulerStorage1.Resources.Mappings.Image = "Image"
        End Sub

        Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            For Each apt As Appointment In e.Objects
                Dim o As XPBaseObject = TryCast(apt.GetSourceObject(CType(sender, SchedulerStorage)), XPBaseObject)
                If o IsNot Nothing Then o.Save()
            Next
        End Sub
    End Class
End Namespace

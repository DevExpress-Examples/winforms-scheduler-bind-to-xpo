Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler

Namespace XPO_XtraScheduler_Simple_Example
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            session1.ConnectionString = "XpoProvider=InMemoryDataStore"

            schedulerDataStorage1.Appointments.DataSource = xpAppointmentCollection
            schedulerDataStorage1.Resources.DataSource = xpResourceCollection

            CreateMappings()
            InitData()

            AddHandler schedulerDataStorage1.AppointmentsChanged, AddressOf OnAppointmentsChanged
            AddHandler schedulerDataStorage1.AppointmentsInserted, AddressOf OnAppointmentsChanged

            schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource
            schedulerControl1.Views.DayView.TopRowTime = Date.Now.TimeOfDay
        End Sub

        Private Sub InitData()
            If xpResourceCollection.Count = 0 Then
                Dim res1 As Resource = schedulerDataStorage1.CreateResource(1)
                res1.Caption = "First Resource"
                res1.ColorValue = "LightSkyBlue"
                schedulerDataStorage1.Resources.Add(res1)
                Dim res2 As Resource = schedulerDataStorage1.CreateResource(2)
                res2.Caption = "Next Resource"
                res2.ColorValue = "LightYellow"
                schedulerDataStorage1.Resources.Add(res2)
                session1.Save(xpResourceCollection)
            End If

            If schedulerDataStorage1.Appointments.Count = 0 Then
                Dim apt1 As Appointment = schedulerDataStorage1.CreateAppointment(AppointmentType.Normal)
                apt1.Start = Date.Now
                apt1.End = apt1.Start.AddHours(2.5F)
                apt1.Subject = "First Appointment"
                apt1.LabelKey = 1
                apt1.ResourceId = schedulerDataStorage1.Resources(0).Id
                schedulerDataStorage1.Appointments.Add(apt1)
                session1.Save(xpAppointmentCollection)
            End If
        End Sub

        Private Sub CreateMappings()
            Me.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerDataStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerDataStorage1.Appointments.Mappings.End = "Finish"
            Me.schedulerDataStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerDataStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
            Me.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
            Me.schedulerDataStorage1.Appointments.Mappings.ResourceId = "Resource!Key"
            Me.schedulerDataStorage1.Appointments.Mappings.Start = "Created"
            Me.schedulerDataStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerDataStorage1.Appointments.Mappings.Type = "AppointmentType"

            Me.schedulerDataStorage1.Resources.Mappings.Caption = "Name"
            Me.schedulerDataStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerDataStorage1.Resources.Mappings.Id = "Oid"
            Me.schedulerDataStorage1.Resources.Mappings.Image = "Image"
        End Sub

        Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            For Each apt As Appointment In e.Objects
                Dim o As XPBaseObject = TryCast(apt.GetSourceObject(DirectCast(sender, SchedulerDataStorage)), XPBaseObject)
                If o IsNot Nothing Then
                    o.Save()
                End If
            Next apt
        End Sub
    End Class
End Namespace

Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace XPO_XtraScheduler_Simple_Example
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            session1.ConnectionString = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("XPO_XtraScheduler_Simple_Example.mdb")

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
                res1.ColorValue = "LightSkyBlue"
                schedulerStorage1.Resources.Add(res1)
                Dim res2 As Resource = schedulerStorage1.CreateResource(2)
                res2.Caption = "Next Resource"
                res2.ColorValue = "LightYellow"
                schedulerStorage1.Resources.Add(res2)
                session1.Save(xpResourceCollection)
            End If

            If schedulerStorage1.Appointments.Count = 0 Then
                Dim apt1 As Appointment = schedulerStorage1.CreateAppointment(AppointmentType.Normal)
                apt1.Start = Date.Now
                apt1.End = apt1.Start.AddHours(2.5F)
                apt1.Subject = "First Appointment"
                apt1.LabelKey = 1
                apt1.ResourceId = schedulerStorage1.Resources(0).Id
                schedulerStorage1.Appointments.Add(apt1)
                session1.Save(xpAppointmentCollection)
            End If
        End Sub

        Private Sub CreateMappings()
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.End = "Finish"
            Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
            Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
            Me.schedulerStorage1.Appointments.Mappings.ResourceId = "Resource!Key"
            Me.schedulerStorage1.Appointments.Mappings.Start = "Created"
            Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.Type = "AppointmentType"

            Me.schedulerStorage1.Resources.Mappings.Caption = "Name"
            Me.schedulerStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerStorage1.Resources.Mappings.Id = "Oid"
            Me.schedulerStorage1.Resources.Mappings.Image = "Image"
        End Sub

        Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            For Each apt As Appointment In e.Objects
                Dim o As XPBaseObject = TryCast(apt.GetSourceObject(DirectCast(sender, SchedulerStorage)), XPBaseObject)
                If o IsNot Nothing Then
                    o.Save()
                End If
            Next apt
        End Sub
    End Class
End Namespace

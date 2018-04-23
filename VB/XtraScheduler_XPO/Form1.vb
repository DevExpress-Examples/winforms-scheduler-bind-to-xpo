Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.Xpo

Namespace XtraScheduler_XPO
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			schedulerStorage1.Appointments.DataSource = Me.xpCollection1

			schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
			schedulerStorage1.Appointments.Mappings.Description = "Description"
			schedulerStorage1.Appointments.Mappings.End = "Finish"
			schedulerStorage1.Appointments.Mappings.Label = "Label"
			schedulerStorage1.Appointments.Mappings.Location = "Location"
			schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
			schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
			schedulerStorage1.Appointments.Mappings.Start = "Start"
			schedulerStorage1.Appointments.Mappings.Status = "Status"
			schedulerStorage1.Appointments.Mappings.Subject = "Subject"
			schedulerStorage1.Appointments.Mappings.Type = "AppointmentType"
			schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId"

			schedulerStorage1.Resources.Mappings.Id = "ResourceId"
			schedulerStorage1.Resources.Mappings.Caption = "Name"
			schedulerStorage1.Resources.Mappings.Color = "Color"


			schedulerControl1.Start = DateTime.Today
			schedulerControl1.GroupType = SchedulerGroupType.Resource
			FillData()
		End Sub


		Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsChanged, schedulerStorage1.AppointmentsInserted, schedulerStorage1.AppointmentsDeleted
			For Each apt As Appointment In e.Objects
				Dim o As XPBaseObject = TryCast(apt.GetSourceObject(CType(sender, SchedulerStorage)), XPBaseObject)
				If o IsNot Nothing Then
					o.Save()
				End If
			Next apt
		End Sub

		Private Sub FillData()
			If Me.schedulerStorage1.Resources.Count = 0 Then
				Dim res1 As Resource = Me.schedulerStorage1.CreateResource(1)
				res1.Caption = "First Resource"
				res1.Color = Color.LightSkyBlue
				Me.schedulerStorage1.Resources.Add(res1)
				Dim res2 As Resource = Me.schedulerStorage1.CreateResource(2)
				res2.Caption = "Next Resource"
				res2.Color = Color.LightYellow
				Me.schedulerStorage1.Resources.Add(res2)
			End If

			If Me.schedulerStorage1.Appointments.Count = 0 Then
				Dim apt1 As Appointment = Me.schedulerStorage1.CreateAppointment(AppointmentType.Normal)
				apt1.Start = DateTime.Now
				apt1.End = apt1.Start.AddHours(2.5f)
				apt1.Subject = "First Appointment"
				apt1.LabelId = 1
				apt1.ResourceId = Me.schedulerStorage1.Resources(0).Id
				Me.schedulerStorage1.Appointments.Add(apt1)
			End If

		End Sub

		Private Sub OnResourcesChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.ResourcesDeleted, schedulerStorage1.ResourcesChanged, schedulerStorage1.ResourcesInserted
			For Each res As Resource In e.Objects
				Dim o As XPBaseObject = TryCast(res.GetSourceObject(CType(sender, SchedulerStorage)), XPBaseObject)
				If o IsNot Nothing Then
					o.Save()
				End If
			Next res
		End Sub

	End Class

End Namespace
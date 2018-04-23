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
			PrepareScheduler()
			PrepareXpCollections()

			EnsureDbConnection()

			schedulerStorage1.Appointments.DataSource = Me.xpCollection1
			schedulerStorage1.Resources.DataSource = Me.xpCollection2

			FillData()
		End Sub

		Private Sub PrepareScheduler()
			Me.schedulerControl1.Start = DateTime.Today
			Me.schedulerControl1.GroupType = SchedulerGroupType.Resource

			Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
			Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
			Me.schedulerStorage1.Appointments.Mappings.End = "Finish"
			Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
			Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
			Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
			Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
			Me.schedulerStorage1.Appointments.Mappings.Start = "Start"
			Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
			Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
			Me.schedulerStorage1.Appointments.Mappings.Type = "AppointmentType"
			Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId"

			Me.schedulerStorage1.Resources.Mappings.Id = "ResourceId"
			Me.schedulerStorage1.Resources.Mappings.Caption = "Name"
			Me.schedulerStorage1.Resources.Mappings.Color = "Color"

			AddHandler Me.schedulerStorage1.ResourcesDeleted, AddressOf OnResourcesChanged
			AddHandler Me.schedulerStorage1.AppointmentsChanged, AddressOf OnAppointmentsChanged
			AddHandler Me.schedulerStorage1.ResourcesChanged, AddressOf OnResourcesChanged
			AddHandler Me.schedulerStorage1.ResourcesInserted, AddressOf OnResourcesChanged
			AddHandler Me.schedulerStorage1.AppointmentsInserted, AddressOf OnAppointmentsChanged
			AddHandler Me.schedulerStorage1.AppointmentsDeleted, AddressOf OnAppointmentsChanged
		End Sub
		Private Sub PrepareXpCollections()
			CType(Me.xpCollection2, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xpCollection1, System.ComponentModel.ISupportInitialize).BeginInit()

			Me.xpCollection1.DeleteObjectOnRemove = True
			Me.xpCollection1.DisplayableProperties = "This;Oid;AllDay;Description;Finish;Label;Location;Recurrence;Reminder;Start;Statu" & "s;Subject;AppointmentType;ResourceId"
			Me.xpCollection1.ObjectType = GetType(XtraScheduler_XPO.Task)

			Me.xpCollection2.DeleteObjectOnRemove = True
			Me.xpCollection2.DisplayableProperties = "Name;ResourceId;Color"
			Me.xpCollection2.ObjectType = GetType(XtraScheduler_XPO.XPResource)

			CType(Me.xpCollection1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xpCollection2, System.ComponentModel.ISupportInitialize).EndInit()
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
		Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
			For Each apt As Appointment In e.Objects
				Dim o As XPBaseObject = TryCast(apt.GetSourceObject(CType(sender, SchedulerStorage)), XPBaseObject)
				If o IsNot Nothing Then
					o.Save()
				End If
			Next apt
		End Sub
		Private Sub OnResourcesChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
			For Each res As Resource In e.Objects
				Dim o As XPBaseObject = TryCast(res.GetSourceObject(CType(sender, SchedulerStorage)), XPBaseObject)
				If o IsNot Nothing Then
					o.Save()
				End If
			Next res
		End Sub
		Private Sub EnsureDbConnection()
			Try
				Me.xpCollection1.Session.Connect()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Can't connect to database")
			End Try
		End Sub
	End Class
End Namespace
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo

Namespace XtraScheduler_XPO
	' XP object
	Public Class Task
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		' Appointment.AllDay
		Private _allDay As Boolean
		Public Property AllDay() As Boolean
			Get
				Return _allDay
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue("AllDay", _allDay, value)
			End Set
		End Property

		' Appointment.Description
		Private _description As String
		<Size(SizeAttribute.Unlimited)> _
		Public Property Description() As String
			Get
				Return _description
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Description", _description, value)
			End Set
		End Property

		' Appointment.End
		Private _finish As DateTime
		Public Property Finish() As DateTime
			Get
				Return _finish
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("Finish", _finish, value)
			End Set
		End Property

		' Appointment.Label
		Private _label As Integer
		Public Property Label() As Integer
			Get
				Return _label
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Label", _label, value)
			End Set
		End Property

		' Appointment.Location
		Private _location As String
		Public Property Location() As String
			Get
				Return _location
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Location", _location, value)
			End Set
		End Property

		' Appointment.RecurrenceInfo
		Private _recurrence As String
		<Size(SizeAttribute.Unlimited)> _
		Public Property Recurrence() As String
			Get
				Return _recurrence
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Recurrence", _recurrence, value)
			End Set
		End Property

		' Appointment.ReminderInfo
		Private _reminder As String
		<Size(SizeAttribute.Unlimited)> _
		Public Property Reminder() As String
			Get
				Return _reminder
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Reminder", _reminder, value)
			End Set
		End Property

		' Appointment.Start
		Private _start As DateTime
		Public Property Start() As DateTime
			Get
				Return _start
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("Start", _start, value)
			End Set
		End Property

		' Appointment.Status
		Private _status As Integer
		Public Property Status() As Integer
			Get
				Return _status
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Status", _status, value)
			End Set
		End Property

		' Appointment.Subject
		Private _subject As String
		Public Property Subject() As String
			Get
				Return _subject
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Subject", _subject, value)
			End Set
		End Property

		' Appointment.Type
		Private _appointmentType As Integer
		Public Property AppointmentType() As Integer
			Get
				Return _appointmentType
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("AppointmentType", _appointmentType, value)
			End Set
		End Property

		' Appointment.ResourceId
		Private _resourceId As Integer
		Public Property ResourceId() As Integer
			Get
				Return _resourceId
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("ResourceId", _resourceId, value)
			End Set
		End Property


			<Association()> _
			Public ReadOnly Property Resources() As XPCollection(Of XPResource)
			Get
				Return GetCollection(Of XPResource)("Resources")
			End Get
			End Property
	End Class

	' XP object
	Public Class XPResource
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		' Resource identifier
		Private _resourceId As Integer
		Public Property ResourceId() As Integer
			Get
				Return _resourceId
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("ResourceId", _resourceId, value)
			End Set
		End Property

		' Resource identifier
		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _name, value)
			End Set
		End Property

		Private _color As Integer
		Public Property Color() As Integer
			Get
				Return _color
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Color", _color, value)
			End Set
		End Property

		<Association()> _
		Public ReadOnly Property Tasks() As XPCollection(Of Task)
			Get
				Return GetCollection(Of Task)("Tasks")
			End Get
		End Property
	End Class



End Namespace
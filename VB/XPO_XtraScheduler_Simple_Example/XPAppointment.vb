Imports DevExpress.Xpo

Namespace XPO_XtraScheduler_Simple_Example

'#Region "#xpappointment"
    ' XP object
    Public Class XPAppointment
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public AllDay As Boolean ' Appointment.AllDay

        <Size(SizeAttribute.Unlimited)>
        Public Description As String ' Appointment.Description

        Public Finish As Date ' Appointment.End

        Public Label As Integer ' Appointment.Label

        Public Location As String ' Appointment.Location

        <Size(SizeAttribute.Unlimited)>
        Public Recurrence As String ' Appointment.RecurrenceInfo

        <Size(SizeAttribute.Unlimited)>
        Public Reminder As String ' Appointment.ReminderInfo

        Public Created As Date ' Appointment.Start

        Public Status As Integer ' Appointment.Status

        <Size(SizeAttribute.Unlimited)>
        Public Subject As String ' Appointment.Subject

        Public AppointmentType As Integer ' Appointment.Type

        Public Resource As XPResource
    End Class
'#End Region  ' #xpappointment
End Namespace

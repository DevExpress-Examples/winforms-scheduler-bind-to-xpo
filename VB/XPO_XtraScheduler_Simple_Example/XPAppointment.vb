Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Xml
Imports System

Namespace XPO_XtraScheduler_Simple_Example
    #Region "#xpappointment"
    ' XP object
    Public Class XPAppointment
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public AllDay As Boolean ' Appointment.AllDay

        <Size(SizeAttribute.Unlimited)> _
        Public Description As String ' Appointment.Description -  !!! To set the Memo field type.

        Public Finish As Date ' Appointment.End
        Public Label As Integer ' Appointment.Label
        Public Location As String ' Appointment.Location

        <Size(SizeAttribute.Unlimited)> _
        Public Recurrence As String ' Appointment.RecurrenceInfo -  !!! To set the Memo field type.

        <Size(SizeAttribute.Unlimited)> _
        Public Reminder As String ' Appointment.ReminderInfo -  !!! To set the Memo field type.

        Public Created As Date ' Appointment.Start
        Public Status As Integer ' Appointment.Status
        <Size(SizeAttribute.Unlimited)> _
        Public Subject As String ' Appointment.Subject -  !!! To set the Memo field type.
        Public AppointmentType As Integer ' Appointment.Type
        Public Resource As XPResource
    End Class
    #End Region ' #xpappointment
End Namespace
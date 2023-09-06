Imports DevExpress.Xpo
Imports System.Drawing

Namespace XPO_XtraScheduler_Simple_Example

'#Region "#xpresource"
    ' XP object
    Public Class XPResource
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public ResId As Integer

        <Size(SizeAttribute.Unlimited)>
        Public Name As String ' Resource.Caption

        Public Color As Integer

        Public Image As Image
    End Class
'#End Region  ' #xpresource
End Namespace

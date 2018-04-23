Namespace XPO_XtraScheduler_Simple_Example
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.session1 = New DevExpress.Xpo.Session(Me.components)
            Me.xpAppointmentCollection = New DevExpress.Xpo.XPCollection(Me.components)
            Me.xpResourceCollection = New DevExpress.Xpo.XPCollection(Me.components)
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.session1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.xpAppointmentCollection, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.xpResourceCollection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(784, 561)
            Me.schedulerControl1.Start = New Date(2015, 9, 29, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' session1
            ' 
            Me.session1.IsObjectModifiedOnNonPersistentPropertyChange = Nothing
            Me.session1.TrackPropertiesModifications = False
            ' 
            ' xpAppointmentCollection
            ' 
            Me.xpAppointmentCollection.DeleteObjectOnRemove = True
            Me.xpAppointmentCollection.ObjectType = GetType(XPO_XtraScheduler_Simple_Example.XPAppointment)
            Me.xpAppointmentCollection.Session = Me.session1
            ' 
            ' xpResourceCollection
            ' 
            Me.xpResourceCollection.ObjectType = GetType(XPO_XtraScheduler_Simple_Example.XPResource)
            Me.xpResourceCollection.Session = Me.session1
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.session1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.xpAppointmentCollection, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.xpResourceCollection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Private xpAppointmentCollection As DevExpress.Xpo.XPCollection
        Private session1 As DevExpress.Xpo.Session
        Private xpResourceCollection As DevExpress.Xpo.XPCollection
    End Class
End Namespace


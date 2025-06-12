'This Class contains general definitions for the dymanics

'Status Checked

Public Class ClsDynamics

    'Status of the Iteration
    Public Enum EnIterationStatus
        Running
        Interrupted
        Stopped
        Ready
    End Enum

    'Status of Editmode (e.g. in LSystems)
    Public Enum EnEditMode
        None
        Edit
        Add
    End Enum

    'To copy an object inclusive properties
    Public Sub CopyProperties(Source As Object, Target As Object)
        Dim SourceType As Type = Source.GetType()
        Dim TargetType As Type = Target.GetType()

        For Each PropertyInfo In SourceType.GetProperties()
            If PropertyInfo.CanRead AndAlso PropertyInfo.CanWrite Then
                Dim value = PropertyInfo.GetValue(Source)
                Dim targetProp = TargetType.GetProperty(PropertyInfo.Name)
                If targetProp IsNot Nothing AndAlso targetProp.CanWrite Then
                    targetProp.SetValue(Target, value)
                End If
            End If
        Next
    End Sub

End Class

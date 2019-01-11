Namespace WireCardPay_vb
    ''' <summary>
    ''' Exception thrown by the WireCardNet library if a WireCard-specific error occurs
    ''' </summary>
    <Serializable>
    Public Class WireCardException
        Inherits ApplicationException
        ''' <summary>
        ''' Creates a new instance of WireCardException
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Creates a new instance of WireCardException with error message
        ''' </summary>
        Public Sub New(message As String)
            MyBase.New(message)
        End Sub

        ''' <summary>
        ''' Creates a new instance of WireCardException with error message and inner exception
        ''' </summary>
        Public Sub New(message As String, innerException As Exception)
            MyBase.New(message, innerException)
        End Sub
    End Class
End Namespace

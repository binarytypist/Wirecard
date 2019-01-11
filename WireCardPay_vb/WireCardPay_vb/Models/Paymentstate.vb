Namespace WireCardPay_vb

    Public Enum PaymentState
        ''' <summary>
        ''' The payment was successfully processed
        ''' </summary>
        Success

        ''' <summary>
        ''' The payment was cancelled by the user
        ''' </summary>
        Cancel

        ''' <summary>
        ''' The payment failed
        ''' </summary>
        Failure
    End Enum
End Namespace
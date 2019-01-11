
Namespace WireCardPay_vb
    Public Class Order
        Private _Id As Guid
        Private _OrderLines As List(Of OrderLine)
        ' Private _Transactions As List(Of CheckoutSuccessResponse)
        Private _State As OrderState

        Public Property Id() As Guid
            Get
                Return _Id
            End Get
            Set
                _Id = Value
            End Set
        End Property

        Public ReadOnly Property Amount() As Decimal
            Get
                Return Me.OrderLines.Sum(Function(c) c.Amount)
            End Get
        End Property

        Public Property OrderLines() As List(Of OrderLine)
            Get
                Return _OrderLines
            End Get
            Set
                _OrderLines = Value
            End Set
        End Property


        'Public Property Transactions() As List(Of CheckoutSuccessResponse)
        '    Get
        '        Return _Transactions
        '    End Get
        '    Set
        '        _Transactions = Value
        '    End Set
        'End Property

        Public Property State() As OrderState
            Get
                Return _State
            End Get
            Set
                _State = Value
            End Set
        End Property

    End Class

    Public Enum OrderState
        Cart
        Preauthorized
        Captured
    End Enum

    Public Class OrderLine
        Public Property Id() As Guid
            Get
                Return _Id
            End Get
            Set
                _Id = Value
            End Set
        End Property
        Private _Id As Guid
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set
                _Name = Value
            End Set
        End Property
        Private _Name As String
        Public Property Amount() As Decimal
            Get
                Return m_Amount
            End Get
            Set
                m_Amount = Value
            End Set
        End Property
        Private m_Amount As Decimal
    End Class

    Public Class Transaction
        Public Property Amount() As Decimal
            Get
                Return m_Amount
            End Get
            Set
                m_Amount = Value
            End Set
        End Property
        Private m_Amount As Decimal
        Public Property GatewayContractNumber() As String
            Get
                Return m_GatewayContractNumber
            End Get
            Set
                m_GatewayContractNumber = Value
            End Set
        End Property
        Private m_GatewayContractNumber As String
        Public Property GatewayReferenceNumber() As String
            Get
                Return m_GatewayReferenceNumber
            End Get
            Set
                m_GatewayReferenceNumber = Value
            End Set
        End Property
        Private m_GatewayReferenceNumber As String
        Public Property TransactionId() As String
            Get
                Return m_TransactionId
            End Get
            Set
                m_TransactionId = Value
            End Set
        End Property

        Public Property Currency As String
        Private m_TransactionId As String
    End Class
End Namespace
Imports System.Collections.Concurrent

Namespace WireCardPay_vb
    Public NotInheritable Class OrderService
        Private Sub New()
        End Sub
        Private Shared ReadOnly Orders As New ConcurrentDictionary(Of Guid, Order)()


        Public Shared Function Create() As Order

            Dim order = New Order() With {
            .Id = Guid.NewGuid(),
                .OrderLines = New List(Of OrderLine)() From {
                    New OrderLine() With {
                       .Id = Guid.NewGuid(),
                        .Name = "Orderline 1",
                        .Amount = 50.29D
                    },
                    New OrderLine() With {
                        .Id = Guid.NewGuid(),
                        .Name = "Orderline 2",
                        .Amount = 50.29D
                    }
                },
                .State = OrderState.Cart
            }

            Return Order

        End Function

        Public Shared Sub AddOrUpdate(order As Order)
            Orders.AddOrUpdate(order.Id, order, Function(guid, order1) order)
        End Sub

        Public Shared Function GetQuery() As IQueryable(Of Order)
            Return Orders.Values.AsQueryable()
        End Function

        Public Shared Sub ClearAll()
            Orders.Clear()
        End Sub
    End Class
End Namespace

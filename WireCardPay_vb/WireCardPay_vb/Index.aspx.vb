Imports WireCardPay_vb.WireCardPay_vb
Imports WireCardPay_vb.WireCardPay_vb.Checkout

Public Class Index
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim url As String = "https://secure.wirecard-cee.com/qpay/init.php"
        Dim data = New Checkout()
        Dim ndata = Data.GetFormData
        Checkout.RedirectWithData(ndata, url)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        'Dim url As String = "https://secure.wirecard-cee.com/qpay/init.php"
        'Dim data = New Checkout()
        'Dim ndata = data.GetFormData
        'Checkout.RedirectWithData(ndata, url)
    End Sub


End Class




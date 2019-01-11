
Imports System.Security.Cryptography
Imports WireCardPay_vb
Imports WireCardPay_vb.WireCardPay_vb
Imports System.Globalization
Namespace WireCardPay_vb
    Public Class IProcedure

        'Private Shared orderID As String


        'Public Function GetFormValues() As NameValueCollection
        '    Checkout.CheckoutProcedure()

        '    Dim order = OrderService.Create()
        '    OrderService.AddOrUpdate(order)
        '    orderID = order.Id.ToString
        '    Dim Amount = order.Amount
        '    Dim obj As Checkout = New Checkout()
        '    Dim Currency = obj.Currency
        '    Dim Language = obj.Language
        '    Dim SuccesURL = obj.SuccessURL
        '    Dim CancelURL = obj.CancelURL
        '    Dim FailureURL = obj.FailureURL
        '    Dim ServiceURL = obj.ServiceURL
        '    Dim ConfirmURL = obj.ConfirmURL
        '    Dim DisplayText = obj.DisplayText
        '    Dim OrderDescription = obj.OrderDescription
        '    Dim PaymentType = obj.PaymentType
        '    Dim ImageURL = obj.ImageURL
        '    Dim DuplicateCheck = obj.DuplicateRequestCheck

        '    ''WireCardPay spefification 
        '    Dim customerID = Customer.CustomerId
        '    Dim secretID = Customer.CustomerSecret
        '    Dim b = New FingerPrintProcedure(Customer.CustomerSecret)

        '    b.AddValue("orderId", orderID)
        '    b.AddValue("customerId", customerID)
        '    If Not String.IsNullOrEmpty(Customer.ShopId) Then
        '        b.AddValue("shopId", Customer.ShopId)
        '    End If
        '    b.AddValue("amount", Amount.ToString("0.00", CultureInfo.InvariantCulture))
        '    'used EUR by defualt
        '    b.AddValue("currency", Currency)
        '    If PaymentType <> PaymentType.Undefined Then
        '        b.AddValue("paymenttype", PaymentType.ToString().ToUpper().Replace("_"c, "-"c))
        '    End If
        '    'used [de] by default, for more language need extended the language method.
        '    b.AddValue("language", Language)
        '    b.AddValue("orderDescription", OrderDescription)
        '    If Not String.IsNullOrEmpty(DisplayText) Then
        '        b.AddValue("displayText", DisplayText)
        '    End If

        '    '' Implmentation requred based on the system application 
        '    b.AddValue("successURL", SuccesURL)
        '    b.AddValue("cancelURL", CancelURL)
        '    b.AddValue("failureURL", FailureURL)
        '    b.AddValue("serviceURL", ServiceURL)

        '    ''IMPORTANT required 
        '    If Not String.IsNullOrEmpty("ConfirmURL") Then
        '        b.AddValue("confirmURL", ConfirmURL)
        '    End If

        '    If Not String.IsNullOrEmpty(ImageURL) Then
        '        b.AddValue("imageURL", ImageURL)
        '    End If

        '    If DuplicateCheck Then
        '        b.AddValue("duplicateRequestCheck", "yes")
        '    End If

        '    Dim form = b.GetFormValues()

        '    form.Add("requestFingerprintOrder", b.GetFingerprintOrder())
        '    form.Add("requestFingerprint", b.GetFingerprint())
        '    Return form
        'End Function

        ''**' Page redirect Method under ASPX for VB.NET-6
        'Public Shared Sub RedirectWithData(availableData As NameValueCollection, url As String)
        '    Dim response As HttpResponse = HttpContext.Current.Response
        '    'response.Clear()
        '    Dim str As New StringBuilder()
        '    str.Append("<html>")
        '    str.AppendFormat("<body onload='document.forms[""payForm""].submit()'>")
        '    str.AppendFormat("<form name='payForm' action='{0}' method='post'>", url)
        '    For Each key As String In availableData
        '        str.AppendFormat("<input type='show' name='{0}' value='{1}' />", key, availableData(key))
        '    Next
        '    str.Append("</form></body></html>")
        '    response.Write(str.ToString())
        '    response.[End]()

        'End Sub
        '''MD5 Security Implementation purpose by wirdcard system specification.
        ''' follows the manual for more details 
        'Public Shared Function GetMD5(key As String) As String
        '    Dim md = MD5.Create()
        '    Dim hash = md.ComputeHash(Encoding.UTF8.GetBytes(key))
        '    Return hash.Aggregate("", Function(current, b) current + b.ToString("x02"))
        'End Function

        '''' Implement the custom parameter to the request
        'Private ReadOnly customParameters As New NameValueCollection()

    End Class
End Namespace

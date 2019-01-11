Imports System.Security.Cryptography

Namespace WireCardPay_vb
    'Friend Class FingerPrintProcedure
    '    'Private ReadOnly autoAppendFingerprintOrder As Boolean = True
    '    'Private ReadOnly formValues As New NameValueCollection()
    '    'Private ReadOnly order As New List(Of String)()
    '    'Private ReadOnly seed As New StringBuilder()

    '    '' <summary>
    '    '' Creates a new Fingerprintbuilder
    '    '' </summary>
    '    '' <param name="secret">The customer secret</param>
    '    'Public Sub New(secret As String)
    '    '    Me.seed.Append(secret)
    '    '    Me.order.Add("secret")
    '    'End Sub

    '    'Private Sub New()
    '    '    Me.autoAppendFingerprintOrder = False
    '    'End Sub

    '    'Public Sub AddValue(name As String, value As String, Optional addToSeed As Boolean = True, Optional addToFormValues As Boolean = True)
    '    '    If addToSeed Then
    '    '        Me.seed.Append(value)
    '    '        Me.order.Add(name)
    '    '    End If

    '    '    If addToFormValues Then
    '    '        Me.formValues.Add(name, value)
    '    '    End If
    '    'End Sub

    '    'Conversion into MD5 
    '    'Protected Function GetMD5(seed As String) As String
    '    '    Dim md = MD5.Create()
    '    '    Dim hash = md.ComputeHash(Encoding.UTF8.GetBytes(seed))
    '    '    Return hash.Aggregate("", Function(current, b) current + b.ToString("x02"))
    '    'End Function
    '    '''' <summary>
    '    '''' Returns the fingerprint
    '    '''' </summary>
    '    '''' <returns></returns>
    '    'Public Function GetFingerprint() As String
    '    '    Return GetMD5(Me.seed.ToString() + GetFingerprintOrder().ToString())
    '    'End Function

    '    'Public Function GetFingerprintOrder()
    '    '    Return String.Join(",", (If(Me.autoAppendFingerprintOrder, Me.order.Concat(New String() {"requestFingerprintOrder"}), Me.order)))
    '    'End Function

    '    '' <summary>
    '    '' Returns all form values
    '    '' </summary>
    '    '' <returns></returns>
    '    'Public Function GetFormValues() As NameValueCollection
    '    '    Return New NameValueCollection(Me.formValues)
    '    'End Function
    'End Class
End Namespace

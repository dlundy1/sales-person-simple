Public Class Form1


    'Declares Base Pay, Quote, and Commission Constants.
    Private basePay_CONST = 250, quota_CONST = 1000, c_rate_CONST = 0.15
    Private WeeklySales_DBL, Commission_DBL, Pay_DBL As Double
    Private WeeklySales_STR, Commission_STR, Pay_STR As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayToolStripMenuItem.Click
        ' Calculate and displays the commission and total for sales person.

        Dim EmployeeName = "Unknown"
        'Dim WeeklySales_DBL, Commission_DBL, Pay_DBL As Double
        'Dim WeeklySales_STR, Commission_STR, Pay_STR As String

        If WeeklySales_Box.Text = "" Or SalesPersonName_Box.Text = "" Then
            Dim messageString = "Invalid Input, Try again."
            MessageBox.Show(messageString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            WeeklySales_DBL = Double.Parse(WeeklySales_Box.Text)
            EmployeeName = SalesPersonName_Box.Text

            If WeeklySales_DBL >= quota_CONST Then
                Commission_DBL = WeeklySales_DBL * c_rate_CONST
                Pay_DBL = basePay_CONST + Commission_DBL
                Commission_Label.Visible = True
            Else
                Pay_DBL = basePay_CONST
            End If

            'WeeklySales_STR = WeeklySales_DBL.ToString()
            Commission_STR = Commission_DBL.ToString()
            Pay_STR = Pay_DBL.ToString()

            Total_Pay_Text.Text = "Total Pay: " & Pay_STR
            Commission_Label.Text = "Commission: " & Commission_STR

        End If

        Debug.WriteLine("Employee-Name: " & EmployeeName)
        Debug.WriteLine("Base Pay: " & basePay_CONST)
        Debug.WriteLine("Commission-Rate: " & c_rate_CONST)
        Debug.WriteLine("Commission: " & Commission_DBL)
        Debug.WriteLine("Pay: " & Pay_DBL)
        Debug.WriteLine("Quota: " & quota_CONST)


    End Sub

    Private Sub SummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryToolStripMenuItem.Click
        ' Display message-box  that holds total sales, total commissions, and total pay for all salespersons.
        Dim message1 = "Sales: ", message2 = "Commission: ", message3 = "Pay: "
        MessageBox.Show(message1 & WeeklySales_DBL & Environment.NewLine &
                        message2 & Commission_DBL & Environment.NewLine &
                        message3 & Pay_DBL, "Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ' Clears the name, sales, and pay for the current employee and then resets Focus

        WeeklySales_DBL = 0
        Commission_DBL = 0
        Pay_DBL = 0

        WeeklySales_STR = ""
        Commission_STR = ""
        Pay_STR = ""
        Total_Pay_Text.Text = "Total Pay: "
        SalesPersonName_Box.Text = ""
        WeeklySales_Box.Text = ""
        SalesPersonName_Box.Focus()
        Commission_Label.Visible = False

    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        ' Changes font of Information displayed in total pay text box
        FontDialog1.ShowDialog()
        Total_Pay_Text.Font = FontDialog1.Font
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        ' Changes color of Information displayed in total pay box
        ColorDialog1.ShowDialog()
        Total_Pay_Text.ForeColor = ColorDialog1.Color

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        ' Use message box to display program name and my name.
        Dim message = "Sales Program | Created By Deon L."
        MessageBox.Show(message, "About Designer", MessageBoxButtons.OK)
    End Sub
End Class

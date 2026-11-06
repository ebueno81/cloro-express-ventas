Imports System.Data
Imports System.Windows.Forms

Module ModUtils

    Public Sub CargarComboMoneda(ByVal Combo As ComboBox)

        Dim Dt As New DataTable

        Dt.Columns.Add("Codigo", GetType(String))
        Dt.Columns.Add("Descripcion", GetType(String))

        Dt.Rows.Add("PEN", "Soles (PEN)")
        Dt.Rows.Add("USD", "Dólares (USD)")

        Combo.DataSource = Nothing
        Combo.DisplayMember = "Descripcion"
        Combo.ValueMember = "Codigo"
        Combo.DataSource = Dt

        Combo.SelectedIndex = -1

    End Sub

End Module
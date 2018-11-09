<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rating
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BmB_DataDataSet1 = New BMBSchedulingSoftware.BMB_DataDataSet()
        Me.EmployeeAvailabilityTableAdapter1 = New BMBSchedulingSoftware.BMB_DataDataSetTableAdapters.EmployeeAvailabilityTableAdapter()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.EmployeeAvailabilityBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartingPeriodsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RatingDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BmB_DataDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeAvailabilityBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BmB_DataDataSet1
        '
        Me.BmB_DataDataSet1.DataSetName = "BMB_DataDataSet"
        Me.BmB_DataDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeeAvailabilityTableAdapter1
        '
        Me.EmployeeAvailabilityTableAdapter1.ClearBeforeFill = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmployeeIDDataGridViewTextBoxColumn, Me.StartingPeriodsDataGridViewTextBoxColumn, Me.RatingDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.EmployeeAvailabilityBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(691, 728)
        Me.DataGridView1.TabIndex = 0
        '
        'EmployeeAvailabilityBindingSource
        '
        Me.EmployeeAvailabilityBindingSource.DataMember = "EmployeeAvailability"
        Me.EmployeeAvailabilityBindingSource.DataSource = Me.BmB_DataDataSet1
        '
        'EmployeeIDDataGridViewTextBoxColumn
        '
        Me.EmployeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID"
        Me.EmployeeIDDataGridViewTextBoxColumn.HeaderText = "Employee ID"
        Me.EmployeeIDDataGridViewTextBoxColumn.Name = "EmployeeIDDataGridViewTextBoxColumn"
        '
        'StartingPeriodsDataGridViewTextBoxColumn
        '
        Me.StartingPeriodsDataGridViewTextBoxColumn.DataPropertyName = "StartingPeriods"
        Me.StartingPeriodsDataGridViewTextBoxColumn.HeaderText = "Available Shift"
        Me.StartingPeriodsDataGridViewTextBoxColumn.Name = "StartingPeriodsDataGridViewTextBoxColumn"
        '
        'RatingDataGridViewTextBoxColumn
        '
        Me.RatingDataGridViewTextBoxColumn.DataPropertyName = "Rating"
        Me.RatingDataGridViewTextBoxColumn.HeaderText = "Shift Rating"
        Me.RatingDataGridViewTextBoxColumn.Name = "RatingDataGridViewTextBoxColumn"
        '
        'Rating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 728)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Rating"
        Me.Text = "frmRating"
        CType(Me.BmB_DataDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeAvailabilityBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BmB_DataDataSet1 As BMB_DataDataSet
    Friend WithEvents EmployeeAvailabilityTableAdapter1 As BMB_DataDataSetTableAdapters.EmployeeAvailabilityTableAdapter
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents EmployeeAvailabilityBindingSource As BindingSource
    Friend WithEvents EmployeeIDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StartingPeriodsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RatingDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class

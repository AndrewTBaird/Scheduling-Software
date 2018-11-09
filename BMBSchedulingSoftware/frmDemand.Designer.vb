<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Demand
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
        Me.PeriodDemandTableAdapter1 = New BMBSchedulingSoftware.BMB_DataDataSetTableAdapters.PeriodDemandTableAdapter()
        Me.TableAdapterManager1 = New BMBSchedulingSoftware.BMB_DataDataSetTableAdapters.TableAdapterManager()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PeriodDemandBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PeriodDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalDemandDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BmB_DataDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeriodDemandBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BmB_DataDataSet1
        '
        Me.BmB_DataDataSet1.DataSetName = "BMB_DataDataSet"
        Me.BmB_DataDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PeriodDemandTableAdapter1
        '
        Me.PeriodDemandTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.EmployeeAvailabilityTableAdapter = Nothing
        Me.TableAdapterManager1.EmployeesTableAdapter = Nothing
        Me.TableAdapterManager1.PeriodDemandTableAdapter = Me.PeriodDemandTableAdapter1
        Me.TableAdapterManager1.UpdateOrder = BMBSchedulingSoftware.BMB_DataDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PeriodDataGridViewTextBoxColumn, Me.TotalDemandDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PeriodDemandBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(530, 449)
        Me.DataGridView1.TabIndex = 0
        '
        'PeriodDemandBindingSource
        '
        Me.PeriodDemandBindingSource.DataMember = "PeriodDemand"
        Me.PeriodDemandBindingSource.DataSource = Me.BmB_DataDataSet1
        '
        'PeriodDataGridViewTextBoxColumn
        '
        Me.PeriodDataGridViewTextBoxColumn.DataPropertyName = "Period"
        Me.PeriodDataGridViewTextBoxColumn.HeaderText = "Period"
        Me.PeriodDataGridViewTextBoxColumn.Name = "PeriodDataGridViewTextBoxColumn"
        '
        'TotalDemandDataGridViewTextBoxColumn
        '
        Me.TotalDemandDataGridViewTextBoxColumn.DataPropertyName = "TotalDemand"
        Me.TotalDemandDataGridViewTextBoxColumn.HeaderText = "Total Demand"
        Me.TotalDemandDataGridViewTextBoxColumn.Name = "TotalDemandDataGridViewTextBoxColumn"
        '
        'Demand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 449)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Demand"
        Me.Text = "frmDemand"
        CType(Me.BmB_DataDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeriodDemandBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BmB_DataDataSet1 As BMB_DataDataSet
    Friend WithEvents PeriodDemandTableAdapter1 As BMB_DataDataSetTableAdapters.PeriodDemandTableAdapter
    Friend WithEvents TableAdapterManager1 As BMB_DataDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PeriodDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalDemandDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PeriodDemandBindingSource As BindingSource
End Class

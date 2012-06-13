/*
 * Creado por SharpDevelop.
 * Usuario: ivancf
 * Fecha: 12/06/2012
 * Hora: 11:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace EjemplosGeneracionCodigo
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbFuenteGenerado = new System.Windows.Forms.TextBox();
			this.tbErrores = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbFuenteGenerado
			// 
			this.tbFuenteGenerado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbFuenteGenerado.Location = new System.Drawing.Point(13, 12);
			this.tbFuenteGenerado.Multiline = true;
			this.tbFuenteGenerado.Name = "tbFuenteGenerado";
			this.tbFuenteGenerado.Size = new System.Drawing.Size(641, 347);
			this.tbFuenteGenerado.TabIndex = 0;
			// 
			// tbErrores
			// 
			this.tbErrores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbErrores.Location = new System.Drawing.Point(13, 365);
			this.tbErrores.Multiline = true;
			this.tbErrores.Name = "tbErrores";
			this.tbErrores.Size = new System.Drawing.Size(641, 204);
			this.tbErrores.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 581);
			this.Controls.Add(this.tbErrores);
			this.Controls.Add(this.tbFuenteGenerado);
			this.Name = "MainForm";
			this.Text = "EjemplosGeneracionCodigo";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox tbErrores;
		private System.Windows.Forms.TextBox tbFuenteGenerado;
	}
}

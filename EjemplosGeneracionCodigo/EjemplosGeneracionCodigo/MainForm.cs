/*
 * Creado por SharpDevelop.
 * Usuario: ivancf
 * Fecha: 12/06/2012
 * Hora: 11:04
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EjemplosGeneracionCodigo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
 CodeCompileUnit cu = GeneraCodigo();
 CodeDomProvider dp = CodeDomProvider.CreateProvider("CSharp");
 //Imprimir el código
 StringWriter sw = new StringWriter();
 System.CodeDom.Compiler.IndentedTextWriter itw = new IndentedTextWriter(sw);
 CodeGeneratorOptions go = new CodeGeneratorOptions();
 go.BlankLinesBetweenMembers = false;
 dp.GenerateCodeFromCompileUnit(cu,sw,go);
 this.tbFuenteGenerado.Text = sw.ToString();
 
 //Compilar desde dom
 CompilerParameters cp = new CompilerParameters(new string[]{},"borrame.dll");
 CompilerResults cr = dp.CompileAssemblyFromDom(cp,cu);
 tbErrores.Text = "";
 foreach(CompilerError ce in cr.Errors){
 	tbErrores.Text += String.Format("{0}){1} in {2} at line {3} column {4} isWarning{5}",ce.ErrorNumber,ce.ErrorText,ce.FileName,ce.Line,ce.Column,ce.IsWarning);
 }
		}
		
private CodeCompileUnit GeneraCodigo(){
	//Unidad de Compilación (ensamblado)
	var cu = new CodeCompileUnit();
	cu.ReferencedAssemblies.Add("System.dll");//Ensamblados que enlaza (aunque este debería estar por defecto)
	//Espacio de nombres
	var n = new CodeNamespace("EjemploGeneracionCodigo1");
	cu.Namespaces.Add(n);
	n.Imports.Add(new CodeNamespaceImport("System"));//Espacios de nombres que utiliza este namespace para compilar
	//Clase
	var c = new CodeTypeDeclaration("ClaseGenerada");
	n.Types.Add(c);
	c.BaseTypes.Add(new CodeTypeReference(typeof(System.Timers.Timer)));//Su clase padre
	c.IsPartial = true;
	
	//Atributo de la clase
	CodeMemberField mf = new CodeMemberField(typeof(string),"_atributo");
	c.Members.Add(mf);
	//Propiedad de la clase
	CodeMemberProperty cp = new CodeMemberProperty();
	c.Members.Add(cp);
	cp.Attributes = MemberAttributes.Public | MemberAttributes.Final;//lo de Final para que no sea virtual (por defecto si es público es virtual)
	cp.Type = new CodeTypeReference(typeof(string));
	cp.Name = "atributo";
	CodeFieldReferenceExpression cfre = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_atributo"); 
	CodeMethodReturnStatement mrs = new CodeMethodReturnStatement(cfre);
	cp.GetStatements.Add(mrs);
	//Metodo de la clase
	CodeMemberMethod cmm = new CodeMemberMethod();
	c.Members.Add(cmm);
	cmm.Attributes = MemberAttributes.Public | MemberAttributes.Final;
	cmm.Name = "Metodo1";
	cmm.ReturnType = new CodeTypeReference(typeof(int));
	CodeParameterDeclarationExpression pde = new CodeParameterDeclarationExpression(typeof(int),"enteroDeEntrada");
	cmm.Parameters.Add(pde);
	pde = new CodeParameterDeclarationExpression(typeof(string),"cadenaDeEntrada");
	cmm.Parameters.Add(pde);
	//Declaración de variable
	CodeVariableDeclarationStatement vds = new CodeVariableDeclarationStatement(typeof(string),"aux",new CodePrimitiveExpression("Prueba1") );
	cmm.Statements.Add(vds);
	//Llamar a método arbitrario
		//variable a llamar y método
		CodeMethodReferenceExpression  ctr = new CodeMethodReferenceExpression(new CodeVariableReferenceExpression("Console"),"WriteLine");
		//Llamada en sí con sus parámetros
		CodeMethodInvokeExpression invoke1 = new CodeMethodInvokeExpression( ctr, new CodeExpression[] {new CodePrimitiveExpression("Hola mundo")} );
	cmm.Statements.Add(invoke1);
		
	
	//Código a pelo. Ojo no se puede generar, por ejemplo, un foreach.
	cmm.Statements.Add(new CodeSnippetStatement("foreach(string s in cadenas){"));
	cmm.Statements.Add(new CodeSnippetStatement("Console.WriteLine(s);"));
	cmm.Statements.Add(new CodeSnippetStatement("}"));
	mrs = new CodeMethodReturnStatement(new CodePrimitiveExpression(42));
	cmm.Statements.Add(mrs);
	                         
	return cu;
}
	}
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 17.11.2023 8:37:30
namespace WSSAAModel
{
    
    /// <summary>
    /// There are no comments for WSSAAEntities in the schema.
    /// </summary>
    public partial class WSSAAEntities : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new WSSAAEntities object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public WSSAAEntities(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::System.Data.Services.Common.DataServiceProtocolVersion.V3)
        {
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Note> Note
        {
            get
            {
                if ((this._Note == null))
                {
                    this._Note = base.CreateQuery<Note>("Note");
                }
                return this._Note;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Note> _Note;
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Student> Student
        {
            get
            {
                if ((this._Student == null))
                {
                    this._Student = base.CreateQuery<Student>("Student");
                }
                return this._Student;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Student> _Student;
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToNote(Note note)
        {
            base.AddObject("Note", note);
        }
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToStudent(Student student)
        {
            base.AddObject("Student", student);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private const string ModelPart0 = "<edmx:Edmx Version=\"1.0\" xmlns:edmx=\"http://schemas.microsoft.com/ado/2007/06/edm" +
                "x\"><edmx:DataServices m:DataServiceVersion=\"1.0\" m:MaxDataServiceVersion=\"3.0\" x" +
                "mlns:m=\"http://schemas.microsoft.com/ado/2007/08/dataservices/metadata\"><Schema " +
                "Namespace=\"WSSAAModel\" xmlns=\"http://schemas.microsoft.com/ado/2009/11/edm\"><Ent" +
                "ityType Name=\"Note\"><Key><PropertyRef Name=\"id\" /></Key><Property Name=\"id\" Type" +
                "=\"Edm.Int32\" Nullable=\"false\" /><Property Name=\"subj\" Type=\"Edm.String\" Nullable" +
                "=\"false\" MaxLength=\"10\" FixedLength=\"true\" Unicode=\"true\" /><Property Name=\"note" +
                "1\" Type=\"Edm.Int32\" Nullable=\"false\" /><Property Name=\"student_id\" Type=\"Edm.Int" +
                "32\" /><NavigationProperty Name=\"Student\" Relationship=\"WSSAAModel.FK__Note__stud" +
                "ent_id__3C69FB99\" ToRole=\"Student\" FromRole=\"Note\" /></EntityType><EntityType Na" +
                "me=\"Student\"><Key><PropertyRef Name=\"id\" /></Key><Property Name=\"id\" Type=\"Edm.I" +
                "nt32\" Nullable=\"false\" /><Property Name=\"Name\" Type=\"Edm.String\" Nullable=\"false" +
                "\" MaxLength=\"20\" FixedLength=\"true\" Unicode=\"true\" /><NavigationProperty Name=\"N" +
                "ote\" Relationship=\"WSSAAModel.FK__Note__student_id__3C69FB99\" ToRole=\"Note\" From" +
                "Role=\"Student\" /></EntityType><Association Name=\"FK__Note__student_id__3C69FB99\"" +
                "><End Type=\"WSSAAModel.Student\" Role=\"Student\" Multiplicity=\"0..1\" /><End Type=\"" +
                "WSSAAModel.Note\" Role=\"Note\" Multiplicity=\"*\" /><ReferentialConstraint><Principa" +
                "l Role=\"Student\"><PropertyRef Name=\"id\" /></Principal><Dependent Role=\"Note\"><Pr" +
                "opertyRef Name=\"student_id\" /></Dependent></ReferentialConstraint></Association>" +
                "</Schema><Schema Namespace=\"Laba6\" xmlns=\"http://schemas.microsoft.com/ado/2009/" +
                "11/edm\"><EntityContainer Name=\"WSSAAEntities\" m:IsDefaultEntityContainer=\"true\">" +
                "<EntitySet Name=\"Note\" EntityType=\"WSSAAModel.Note\" /><EntitySet Name=\"Student\" " +
                "EntityType=\"WSSAAModel.Student\" /><AssociationSet Name=\"FK__Note__student_id__3C" +
                "69FB99\" Association=\"WSSAAModel.FK__Note__student_id__3C69FB99\"><End Role=\"Note\"" +
                " EntitySet=\"Note\" /><End Role=\"Student\" EntitySet=\"Student\" /></AssociationSet><" +
                "/EntityContainer></Schema></edmx:DataServices></edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static string GetConcatenatedEdmxString()
            {
                return string.Concat(ModelPart0);
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            public static global::Microsoft.Data.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::Microsoft.Data.Edm.IEdmModel LoadModelFromString()
            {
                string edmxToParse = GetConcatenatedEdmxString();
                global::System.Xml.XmlReader reader = CreateXmlReader(edmxToParse);
                try
                {
                    return global::Microsoft.Data.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
    /// <summary>
    /// There are no comments for WSSAAModel.Note in the schema.
    /// </summary>
    /// <KeyProperties>
    /// id
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("id")]
    public partial class Note
    {
        /// <summary>
        /// Create a new Note object.
        /// </summary>
        /// <param name="ID">Initial value of id.</param>
        /// <param name="subj">Initial value of subj.</param>
        /// <param name="note1">Initial value of note1.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Note CreateNote(int ID, string subj, int note1)
        {
            Note note = new Note();
            note.id = ID;
            note.subj = subj;
            note.note1 = note1;
            return note;
        }
        /// <summary>
        /// There are no comments for Property id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnidChanging(value);
                this._id = value;
                this.OnidChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _id;
        partial void OnidChanging(int value);
        partial void OnidChanged();
        /// <summary>
        /// There are no comments for Property subj in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string subj
        {
            get
            {
                return this._subj;
            }
            set
            {
                this.OnsubjChanging(value);
                this._subj = value;
                this.OnsubjChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _subj;
        partial void OnsubjChanging(string value);
        partial void OnsubjChanged();
        /// <summary>
        /// There are no comments for Property note1 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int note1
        {
            get
            {
                return this._note1;
            }
            set
            {
                this.Onnote1Changing(value);
                this._note1 = value;
                this.Onnote1Changed();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _note1;
        partial void Onnote1Changing(int value);
        partial void Onnote1Changed();
        /// <summary>
        /// There are no comments for Property student_id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Nullable<int> student_id
        {
            get
            {
                return this._student_id;
            }
            set
            {
                this.Onstudent_idChanging(value);
                this._student_id = value;
                this.Onstudent_idChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Nullable<int> _student_id;
        partial void Onstudent_idChanging(global::System.Nullable<int> value);
        partial void Onstudent_idChanged();
        /// <summary>
        /// There are no comments for Student in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public Student Student
        {
            get
            {
                return this._Student;
            }
            set
            {
                this._Student = value;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private Student _Student;
    }
    /// <summary>
    /// There are no comments for WSSAAModel.Student in the schema.
    /// </summary>
    /// <KeyProperties>
    /// id
    /// </KeyProperties>
    [global::System.Data.Services.Common.DataServiceKeyAttribute("id")]
    public partial class Student
    {
        /// <summary>
        /// Create a new Student object.
        /// </summary>
        /// <param name="ID">Initial value of id.</param>
        /// <param name="name">Initial value of Name.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Student CreateStudent(int ID, string name)
        {
            Student student = new Student();
            student.id = ID;
            student.Name = name;
            return student;
        }
        /// <summary>
        /// There are no comments for Property id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnidChanging(value);
                this._id = value;
                this.OnidChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _id;
        partial void OnidChanging(int value);
        partial void OnidChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this._Name = value;
                this.OnNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Note in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Collections.ObjectModel.Collection<Note> Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                if ((value != null))
                {
                    this._Note = value;
                }
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Collections.ObjectModel.Collection<Note> _Note = new global::System.Collections.ObjectModel.Collection<Note>();
    }
}

using IO;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BIZ
{
    public class ClassBiz
    {

        classDBF CDBF = new ClassDBF();
        private ObservableCollection<ClassBog> _boeger = new ObservableCollection<ClassBog>();
        private ObservableCollection<ClassBog> _laanteBoeger= new ObservableCollection<ClassBog>();
        private ClassBog _Bog;
        private ClassPerson _person;
        public ClassBiz()
        {
           
        }

        public ObservableCollection<ClassBog> laanteboeger
        {
            get {  return _laanteBoeger; }
            private set { _laanteBoeger = value; }
        }
        public ObservableCollection<ClassBog> boeger
        {
            get {  return boeger; }
            private set { boeger = value; }
        }
        public ClassPerson person
        {
            get { return _person; }
            set { _person = value; }
        }
        public ClassBog bog
        {
            get { return _Bog; }
            set { _Bog = value; }
        }

        public GetAllLentBoks(ClassPerson person) 
        {
            
            
        }
        public string GetAllBooksWhereTheTitleContainsTheseWords(ClassPerson person)
        {

            return person.id.ToString();
                
        }
        public void LendThisBookToTheUser(ClassBog bog,ClassBog person)
        {
            
        }
        public void SubmiThisBookToTheLibrary(ClassBog bog , ClassPerson person)
        {

        }
        public bool CheckForDoubleLending(ClassBog bog)
        {

        }
    }
}

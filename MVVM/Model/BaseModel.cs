using data_bind.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace data_bind.MVVM.Model
{
    public abstract class BaseModel
    {
        List<Noty> _Notys = new List<Noty>();

        public bool IsValid { get { return IsValidModel(); } }
        public ReadOnlyCollection<Noty> Notys { get { return _Notys.AsReadOnly(); } }

        protected abstract bool IsValidModel(); 

        protected BaseModel()
        {


        }
        protected void AddNoty(Noty noty)
        {
            _Notys.Add(noty);
        }

        protected void RemoveNoty(Noty noty) => _Notys.Remove(noty);
        protected void ClearNoty()=> _Notys.Clear();
        protected void RemoveNoty(Predicate<Noty> predicate ) => _Notys.RemoveAll(predicate);

    }
}

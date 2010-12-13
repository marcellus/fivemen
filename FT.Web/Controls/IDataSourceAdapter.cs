using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace WebControls
{
    public interface IDataSourceAdapter
    {
        int TotalCount { get;}
        object GetPagedData(int start, int end);
    }

    internal class DataViewAdapter : IDataSourceAdapter
    {
        private DataView _view;

        internal DataViewAdapter(DataView view)
        {
            _view = view;
        }
        public int TotalCount
        {
            get { return (_view == null) ? 0 : _view.Table.Rows.Count; }
        }
        public object GetPagedData(int start, int end)
        {
            DataTable table = _view.Table.Clone();

            for (int i = start; i <= end && i <= TotalCount; i++)
            {
                table.ImportRow(_view[i - 1].Row);
            }
            return table;
        }
    }

    public abstract class AdapterBuilder
    {
        private object _source;

        private void CheckForNull()
        {
            if (_source == null) throw new NullReferenceException("必须提供一个合法的数据源");
        }
        public virtual object Source
        {
            get
            {
                CheckForNull();
                return _source;
            }
            set
            {
                _source = value;
                CheckForNull();
            }
        }
        public abstract IDataSourceAdapter Adapter { get;}
    }

    public class DataTableAdapterBuilder : AdapterBuilder
    {
        private DataViewAdapter _adapter;

        private DataViewAdapter ViewAdapter
        {
            get
            {
                if (_adapter == null)
                {
                    DataTable table = (DataTable)Source;
                    _adapter = new DataViewAdapter(table.DefaultView);
                }
                return _adapter;
            }
        }
        public override IDataSourceAdapter Adapter
        {
            get
            {
                return ViewAdapter;
            }
        }
    }
    public class DataViewAdapterBuilder : AdapterBuilder
    {
        private DataViewAdapter _adapter;

        private DataViewAdapter ViewAdapter
        {
            get
            { // 延迟实例化
                if (_adapter == null)
                {
                    _adapter = new DataViewAdapter((DataView)Source);
                }
                return _adapter;
            }
        }
        public override IDataSourceAdapter Adapter
        {
            get { return ViewAdapter; }
        }
    }

    public class AdapterCollection : DictionaryBase
    {
        private string GetKey(Type key)
        {
            return key.FullName;
        }
        public AdapterCollection() { }
        public void Add(Type key, AdapterBuilder value)
        {
            Dictionary.Add(GetKey(key), value);
        }
        public bool Contains(Type key)
        {
            return Dictionary.Contains(GetKey(key));
        }
        public void Remove(Type key)
        {
            Dictionary.Remove(GetKey(key));
        }
        public AdapterBuilder this[Type key]
        {
            get { return (AdapterBuilder)Dictionary[GetKey(key)]; }
            set { Dictionary[GetKey(key)] = value; }
        }


    } 



}

using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Common
{
    public class ExportEntity
    {
        string _key;
        string _name;
        string _expression;
        string _format;
        ushort _width;

        public ExportEntity()
        {
        }

        public ExportEntity(string _key, string _name, string _expression, string _format)
        {
            this._key = _key;
            this._name = _name;
            this._expression = _expression;
            this._format = _format;
        }

        public ExportEntity(string _key, string _name, string _expression, string _format,ushort _width)
        {
            this._key = _key;
            this._name = _name;
            this._expression = _expression;
            this._format = _format;
            this._width = _width;
        }

        public ExportEntity(string _key, string _name, string _expression)
        {
            this._key = _key;
            this._name = _name;
            this._expression = _expression;
            this._format = "";
        }


        public string Key
        {
            set
            {
                this._key = value;
            }
            get
            {
                return this._key;
            }
        }

        public string Name
        {
            set
            {
                this._name = value;
            }
            get
            {
                return this._name;
            }
        }

        public string Expression
        {
            set
            {
                this._expression = value;
            }
            get
            {
                return this._expression;
            }
        }

        public string Format
        {
            set
            {
                this._format = value;
            }
            get
            {
                return this._format;
            }
        }

        public ushort Width
        {
            set
            {
                this._width = value;
            }
            get
            {
                return this._width;
            }
        }
    }
}

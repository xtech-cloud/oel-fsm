namespace XTC.oelFSM
{
    public class Parameter
    {
        public enum Tag
        {
            NULL = 0,
            StringValue = 1,
            IntValue = 2,
            LongValue = 3,
            FloatValue = 4,
            DoubleValue = 5,
            BoolValue = 6,
            CustomValue = 100,
        }

        private object value_ = null;
        private Tag tag_ = Tag.NULL;

        protected Parameter()
        {
        }

        public static Parameter FromString(string _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.StringValue;
            return parameter;
        }

        public static Parameter FromInt(int _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.IntValue;
            return parameter;
        }

        public static Parameter FromLong(long _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.LongValue;
            return parameter;
        }

        public static Parameter FromFloat(float _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.FloatValue;
            return parameter;
        }

        public static Parameter FromDouble(double _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.DoubleValue;
            return parameter;
        }

        public static Parameter FromBool(bool _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.BoolValue;
            return parameter;
        }

        public static Parameter FromCustom(object _value)
        {
            Parameter parameter = new Parameter();
            parameter.value_ = _value;
            parameter.tag_ = Tag.CustomValue;
            return parameter;
        }

        public Parameter(object _value)
        {
            value_ = _value;
            tag_ = Tag.CustomValue;
        }

        public bool IsString { get { return tag_ == Tag.StringValue; } }
        public bool IsInt { get { return tag_ == Tag.IntValue; } }
        public bool IsLong { get { return tag_ == Tag.LongValue; } }
        public bool IsFloat { get { return tag_ == Tag.FloatValue; } }
        public bool IsDouble { get { return tag_ == Tag.DoubleValue; } }
        public bool IsBool { get { return tag_ == Tag.BoolValue; } }
        public bool IsCustom { get { return tag_ == Tag.CustomValue; } }

        public string AsString
        {
            get
            {
                if (Tag.StringValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to string", tag_.ToString()));
                return (string)value_;
            }
            set
            {
                if (Tag.StringValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to string", tag_.ToString()));
                value_ = value;
            }
        }


        public int AsInt
        {
            get
            {
                if (Tag.IntValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to int", tag_.ToString()));

                return (int)value_;
            }
            set
            {
                if (Tag.IntValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to int", tag_.ToString()));
                value_ = value;
            }
        }

        public long AsLong
        {
            get
            {
                if (Tag.LongValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to long", tag_.ToString()));

                return (long)value_;
            }
            set
            {
                if (Tag.LongValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to long", tag_.ToString()));
                value_ = value;
            }
        }

        public float AsFloat
        {
            get
            {
                if (Tag.FloatValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to float", tag_.ToString()));

                return (float)value_;
            }
            set
            {
                if (Tag.FloatValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to float", tag_.ToString()));
                value_ = value;
            }
        }

        public virtual double AsDouble
        {
            get
            {
                if (Tag.DoubleValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to double", tag_.ToString()));

                return (double)value_;
            }
            set
            {
                if (Tag.DoubleValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to double", tag_.ToString()));
                value_ = value;
            }
        }

        public virtual bool AsBool
        {
            get
            {
                if (Tag.BoolValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to bool", tag_.ToString()));

                return (bool)value_;
            }
            set
            {
                if (Tag.BoolValue != tag_)
                    throw new System.FormatException(string.Format("ValueError: could not convert {0} to bool", tag_.ToString()));
                value_ = value;
            }
        }

        public virtual T Get<T>()
        {
            if (Tag.CustomValue != tag_)
                throw new System.FormatException(string.Format("ValueError: could not convert {0} to custom", tag_.ToString()));

            if (!(value_ is T))
                throw new System.FormatException(string.Format("ValueError: value is {0}", value_.GetType().FullName));
            return (T)value_;
        }

        public virtual void Set<T>(T _value)
        {
            if (Tag.CustomValue != tag_)
                throw new System.FormatException(string.Format("ValueError: could not convert {0} to custom", tag_.ToString()));

            if (!(value_.GetType() != _value.GetType()))
                throw new System.FormatException(string.Format("ValueError: value is {0}", value_.GetType().FullName));
            value_ = _value;
        }
    }//class
}

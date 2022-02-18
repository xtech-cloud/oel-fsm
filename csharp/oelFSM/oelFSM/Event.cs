namespace XTC.oelFSM
{
    public class Event
    {
        // 事件名称
        public string Name { get; private set; }

        // 事件连接的状态
        public State state { get; set; }

        protected Event()
        {

        }

        internal Event(string _name)
        {
            Name = _name;
        }
    }

}//namespace

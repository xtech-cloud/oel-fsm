namespace XTC.oelFSM
{
    public class Command
    {
        // 命令名称
        public string Name { get; private set; }

        // 命令连接的状态
        public State state { get; set; }

        protected Command()
        {

        }

        internal Command(string _name)
        {
            Name = _name;
        }
    }

}//namespace

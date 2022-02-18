namespace XTC.oelFSM
{
    /// <summary>
    /// 行为
    /// </summary>
    public abstract class Action
    {
        // 行为的状态
        internal enum Status
        {
            STOP,  // 停止
            RUN,   // 运行
            FINISH // 完成
        }


        /// <summary>
        /// 行为的状态
        /// </summary>
        public State state { get; private set; }

        // 当前的状态
        internal Status status { get; private set; }

        protected Action()
        {
        }

        protected abstract void onEnter();
        protected abstract void onExit();
        protected abstract void onUpdate();


        internal void bindState(State _state)
        {
            status = Status.STOP;
            state = _state;
        }

        // 执行进入过程
        internal void doEnter()
        {
            status = Status.RUN;
            onEnter();
        }

        // 执行退出过程
        internal void doExit()
        {
            status = Status.STOP;
            onExit();
        }

        // 执行更新过程
        internal void doUpdate()
        {
            if (Status.RUN != status)
                return;
            onUpdate();
        }

        // 执行完成过程
        protected void finish()
        {
            status = Status.FINISH;
        }

        // 获取参数
        protected Parameter getParameter(string _name)
        {
            return state.machine.GetParameter(_name);
        }

        //设置参数
        protected void setParameter(string _name, Parameter _parameter)
        {
            state.machine.SetParameter(_name, _parameter);
        }
    }
}//namespace

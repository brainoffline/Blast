using System;
using TinyIoC;
using TinyMessenger;

namespace BrainOffline
{
    public class Brain
    {
        private static Brain _singleBrain = new Brain();
        public static TinyIoCContainer Container { get; private set; } = new TinyIoCContainer();

        public static void Reset()
        {
            Container = new TinyIoCContainer();
            _singleBrain = new Brain();
        }

        public static Brain RegisterDependencies( Action<TinyIoCContainer> config )
        {
            config(Container);
            return _singleBrain;
        }

        public T Resolve<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        public static Brain Subscribe<T>(Action<T> deliveryAction) where T : class
        {
            var hub = Container.Resolve<ITinyMessengerHub>();
            hub.Subscribe(deliveryAction);

            return _singleBrain;
        }

        public static void Publish<T>(T message) where T : class
        {
            var hub = Container.Resolve<ITinyMessengerHub>();
            hub.Publish(message);
        }
    }
}

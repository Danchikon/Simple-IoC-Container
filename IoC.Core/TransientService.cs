// namespace IoC.Core;
//
// public class TransientService<TService, TImplementation> : IService<TService> 
//     where TImplementation : TService, new()
// {
//     public TService GetInstance()
//     {
//         return new TImplementation();
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Omu.ValueInjecter;
using Omu.ValueInjecter.Injections;

namespace ReactApi.Helpers
{
    /// <summary>
    /// Extension Methods for Entity Mapper.
    /// </summary>
    public static class EntityMapperExtensions
    {
        /// <summary>
        /// Map list of records to view model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="target"></param>
        /// <param name="model"></param>
        /// <param name="ignoreProperties"></param>
        /// <returns></returns>
        public static List<TViewModel> MapFromModel<TModel, TViewModel>(this object target, List<TModel> model, string ignoreProperties = null)
            where TModel : class, new()
            where TViewModel : class, new()
        {
            return model.ToList().Select(o => new TViewModel().
                                                    InjectFrom(new IgnoreProperty(ignoreProperties), o)).Cast<TViewModel>().ToList();
        }

        /// <summary>
        /// Map single item from model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="target"></param>
        /// <param name="model"></param>
        /// <param name="ignoreProperties"></param>
        /// <returns></returns>
        public static object MapFromModel<TModel>(this object target, TModel model, string ignoreProperties = null) where TModel : class, new()
        {
            target.InjectFrom(new IgnoreProperty(ignoreProperties), model);
            return target;
        }


        /// <summary>
        /// Map from view model
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="target"></param>
        /// <param name="viewModel"></param>
        /// <param name="identity"></param>
        /// <param name="ignoreProperties"></param>
        /// <returns></returns>
        public static object MapFromViewModel<TModel>(this object target, TModel viewModel, ClaimsIdentity identity = null, string ignoreProperties = null) where TModel : class, new()
        {
            target.InjectFrom(new IgnoreProperty(ignoreProperties), viewModel)
                 .InjectFrom<AvoidNullProps>(viewModel);
            if (identity != null)
            {
                target.MapAuditColumns(identity);
            }
            return target;
        }
    }

    /// <summary>
    /// Avoid null properties
    /// </summary>
    public class AvoidNullProps : LoopInjection
    {
        /// <summary>
        /// Implicit method to set value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="sp"></param>
        /// <param name="tp"></param>
        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            var val = sp.GetValue(source);
            if (val != null)
                tp.SetValue(target, val);
        }
    }

    /// <summary>
    /// Ignore properties
    /// </summary>
    public class IgnoreProperty : LoopInjection
    {
        /// <summary>
        /// readonly local variable
        /// </summary>
        private readonly string[] _ignoreProperties;

        /// <summary>
        /// Properties ignore
        /// </summary>
        /// <param name="ignoreProperties"></param>
        public IgnoreProperty(string ignoreProperties)
        {
            if (ignoreProperties != null) { _ignoreProperties = ignoreProperties.Split(';'); }
        }
    }
}

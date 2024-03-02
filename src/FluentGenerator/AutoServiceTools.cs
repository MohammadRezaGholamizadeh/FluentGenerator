using Autofac;
using Autofac.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FluentGenerator
{
    public static class AutoServiceTools
    {
        /* Developer : MohammadReza Gholamizadeh */

        /// <summary>
        /// This Method Add Specific Constructor Parameters to Service Registering Process
        /// </summary>
        /// <typeparam name="TLimit"></typeparam>
        /// <typeparam name="TReflectionActivatorData"></typeparam>
        /// <typeparam name="TStyle"></typeparam>
        /// <param name="registration"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<
            TLimit, TReflectionActivatorData, TStyle>
            WithConstructorParameters<TLimit, TReflectionActivatorData, TStyle>(
            this IRegistrationBuilder<TLimit,
                 TReflectionActivatorData,
                 TStyle> registration,
            Dictionary<Type, object> parameters)
            where TReflectionActivatorData : ReflectionActivatorData
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    registration = registration
                                   .WithParameter(new TypedParameter(
                                                      parameter.Key,
                                                      parameter.Value));
                }
            }

            return registration;
        }
        /// <summary>
        /// This Method Use Your Specific DbContext Instance To Use In Services and EveryWhere That You Need It And Configured
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <typeparam name="TLimit"></typeparam>
        /// <typeparam name="TReflectionActivatorData"></typeparam>
        /// <typeparam name="TStyle"></typeparam>
        /// <param name="registration"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<
             TLimit, TReflectionActivatorData, TStyle>
             WithDbContext<TDbContext, TLimit, TReflectionActivatorData, TStyle>(
             this IRegistrationBuilder<TLimit,
                  TReflectionActivatorData,
                  TStyle> registration,
             TDbContext context)
             where TReflectionActivatorData : ReflectionActivatorData
             where TDbContext : class
        {
            registration = registration
                           .WithParameter(new TypedParameter(
                                              typeof(TDbContext),
                                              context));
            return registration;
        }
        /// <summary>
        /// This Method Add an Element To Specific Dictionary That You Created
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterType"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static Dictionary<Type, object>
            AddMockedParameter(
            this Dictionary<Type, object> parameter,
            Type parameterType,
            object parameterValue)
        {
            parameter.Add(parameterType, parameterValue);
            return parameter;
        }

        public static Dictionary<Type, object>
               MockObjectListCreator()
        {
            return new Dictionary<Type, object>();
        }

        /// <summary>
        /// This Method Save Changes On DbContext that Recognized By ChangeTracker 
        /// </summary>
        /// <param name="context">Specific DbContext</param>
        /// <param name="entity">Entity That You Want Add To DbContext</param>
        public static void
        SaveChangesOn(this DbContext context, object entity)
        {
            context.Add(entity).Context.SaveChanges();
        }
    }
}

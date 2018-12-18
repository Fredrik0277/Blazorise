﻿#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
#endregion

namespace Blazorise.Base
{
    public abstract class BaseBreadcrumbLink : BaseComponent
    {
        #region Members

        private bool isDisabled;

        #endregion

        #region Methods

        protected override void RegisterClasses()
        {
            ClassMapper
                .Add( () => ClassProvider.BreadcrumbLink() );

            base.RegisterClasses();
        }

        protected void ClickHandler()
        {
            Clicked?.Invoke();
        }

        #endregion

        #region Properties

        protected bool IsParentBreadcrumbItemActive => ParentBreadcrumbItem?.IsActive == true;

        [Parameter]
        protected bool IsDisabled
        {
            get => isDisabled;
            set
            {
                isDisabled = value;

                ClassMapper.Dirty();
            }
        }

        /// <summary>
        /// Occurs when the item is clicked.
        /// </summary>
        [Parameter] protected Action Clicked { get; set; }

        /// <summary>
        /// Page address.
        /// </summary>
        [Parameter] protected string To { get; set; }

        [Parameter] protected Match Match { get; set; } = Match.All;

        [Parameter] protected string Title { get; set; }

        [Parameter] protected RenderFragment ChildContent { get; set; }

        [CascadingParameter] protected BaseBreadcrumbItem ParentBreadcrumbItem { get; set; }

        #endregion
    }
}

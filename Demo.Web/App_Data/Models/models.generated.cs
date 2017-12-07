//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.7.99
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

[assembly: PureLiveAssembly]
[assembly:ModelsBuilderAssembly(PureLive = true, SourceHash = "48a56f282a84a002")]
[assembly:System.Reflection.AssemblyVersion("0.0.0.2")]

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>DealerHomePage</summary>
	[PublishedContentModel("dealerHomePage")]
	public partial class DealerHomePage : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "dealerHomePage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public DealerHomePage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<DealerHomePage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}
	}

	/// <summary>LoginPage</summary>
	[PublishedContentModel("loginPage")]
	public partial class LoginPage : PublishedContentModel, IHideInNavDT
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "loginPage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public LoginPage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<LoginPage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Skjul i navigasjon
		///</summary>
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation
		{
			get { return Umbraco.Web.PublishedContentModels.HideInNavDT.GetHideInNavigation(this); }
		}
	}

	/// <summary>DealerMaster</summary>
	[PublishedContentModel("dealerMaster")]
	public partial class DealerMaster : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "dealerMaster";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public DealerMaster(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<DealerMaster, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}
	}

	/// <summary>MyPage</summary>
	[PublishedContentModel("myPage")]
	public partial class MyPage : PublishedContentModel, IHideInNavDT
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "myPage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public MyPage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<MyPage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Skjul i navigasjon
		///</summary>
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation
		{
			get { return Umbraco.Web.PublishedContentModels.HideInNavDT.GetHideInNavigation(this); }
		}
	}

	/// <summary>EditMyPage</summary>
	[PublishedContentModel("editMyPage")]
	public partial class EditMyPage : PublishedContentModel, IHideInNavDT
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "editMyPage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public EditMyPage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<EditMyPage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Skjul i navigasjon
		///</summary>
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation
		{
			get { return Umbraco.Web.PublishedContentModels.HideInNavDT.GetHideInNavigation(this); }
		}
	}

	/// <summary>ComplaintReports</summary>
	[PublishedContentModel("complaintReports")]
	public partial class ComplaintReports : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "complaintReports";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ComplaintReports(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ComplaintReports, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}
	}

	/// <summary>DashboardComplaintReports</summary>
	[PublishedContentModel("dashboardComplaintReports")]
	public partial class DashboardComplaintReports : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "dashboardComplaintReports";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public DashboardComplaintReports(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<DashboardComplaintReports, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}
	}

	// Mixin content Type 1082 with alias "hideInNavDT"
	/// <summary>HideInNavDT</summary>
	public partial interface IHideInNavDT : IPublishedContent
	{
		/// <summary>Skjul i navigasjon</summary>
		bool HideInNavigation { get; }
	}

	/// <summary>HideInNavDT</summary>
	[PublishedContentModel("hideInNavDT")]
	public partial class HideInNavDT : PublishedContentModel, IHideInNavDT
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "hideInNavDT";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public HideInNavDT(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<HideInNavDT, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Skjul i navigasjon
		///</summary>
		[ImplementPropertyType("hideInNavigation")]
		public bool HideInNavigation
		{
			get { return GetHideInNavigation(this); }
		}

		/// <summary>Static getter for Skjul i navigasjon</summary>
		public static bool GetHideInNavigation(IHideInNavDT that) { return that.GetPropertyValue<bool>("hideInNavigation"); }
	}

	/// <summary>SearchComplaintReportsPage</summary>
	[PublishedContentModel("searchComplaintReportsPage")]
	public partial class SearchComplaintReportsPage : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "searchComplaintReportsPage";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public SearchComplaintReportsPage(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<SearchComplaintReportsPage, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}
	}

	/// <summary>NewComplaintReport</summary>
	[PublishedContentModel("newComplaintReport")]
	public partial class NewComplaintReport : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "newComplaintReport";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public NewComplaintReport(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<NewComplaintReport, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}
	}

	/// <summary>Folder</summary>
	[PublishedContentModel("Folder")]
	public partial class Folder : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "Folder";
		public new const PublishedItemType ModelItemType = PublishedItemType.Media;
#pragma warning restore 0109

		public Folder(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Folder, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Contents:
		///</summary>
		[ImplementPropertyType("contents")]
		public object Contents
		{
			get { return this.GetPropertyValue("contents"); }
		}
	}

	/// <summary>Image</summary>
	[PublishedContentModel("Image")]
	public partial class Image : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "Image";
		public new const PublishedItemType ModelItemType = PublishedItemType.Media;
#pragma warning restore 0109

		public Image(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Image, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Size
		///</summary>
		[ImplementPropertyType("umbracoBytes")]
		public string UmbracoBytes
		{
			get { return this.GetPropertyValue<string>("umbracoBytes"); }
		}

		///<summary>
		/// Type
		///</summary>
		[ImplementPropertyType("umbracoExtension")]
		public string UmbracoExtension
		{
			get { return this.GetPropertyValue<string>("umbracoExtension"); }
		}

		///<summary>
		/// Upload image
		///</summary>
		[ImplementPropertyType("umbracoFile")]
		public Umbraco.Web.Models.ImageCropDataSet UmbracoFile
		{
			get { return this.GetPropertyValue<Umbraco.Web.Models.ImageCropDataSet>("umbracoFile"); }
		}

		///<summary>
		/// Height
		///</summary>
		[ImplementPropertyType("umbracoHeight")]
		public string UmbracoHeight
		{
			get { return this.GetPropertyValue<string>("umbracoHeight"); }
		}

		///<summary>
		/// Width
		///</summary>
		[ImplementPropertyType("umbracoWidth")]
		public string UmbracoWidth
		{
			get { return this.GetPropertyValue<string>("umbracoWidth"); }
		}
	}

	/// <summary>File</summary>
	[PublishedContentModel("File")]
	public partial class File : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "File";
		public new const PublishedItemType ModelItemType = PublishedItemType.Media;
#pragma warning restore 0109

		public File(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<File, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Size
		///</summary>
		[ImplementPropertyType("umbracoBytes")]
		public string UmbracoBytes
		{
			get { return this.GetPropertyValue<string>("umbracoBytes"); }
		}

		///<summary>
		/// Type
		///</summary>
		[ImplementPropertyType("umbracoExtension")]
		public string UmbracoExtension
		{
			get { return this.GetPropertyValue<string>("umbracoExtension"); }
		}

		///<summary>
		/// Upload file
		///</summary>
		[ImplementPropertyType("umbracoFile")]
		public string UmbracoFile
		{
			get { return this.GetPropertyValue<string>("umbracoFile"); }
		}
	}

	/// <summary>Member</summary>
	[PublishedContentModel("Member")]
	public partial class Member : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "Member";
		public new const PublishedItemType ModelItemType = PublishedItemType.Member;
#pragma warning restore 0109

		public Member(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Member, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Adresse
		///</summary>
		[ImplementPropertyType("address")]
		public string Address
		{
			get { return this.GetPropertyValue<string>("address"); }
		}

		///<summary>
		/// Alder
		///</summary>
		[ImplementPropertyType("alder")]
		public DateTime Alder
		{
			get { return this.GetPropertyValue<DateTime>("alder"); }
		}

		///<summary>
		/// Kontaktperson
		///</summary>
		[ImplementPropertyType("contactPerson")]
		public string ContactPerson
		{
			get { return this.GetPropertyValue<string>("contactPerson"); }
		}

		///<summary>
		/// Fronavn
		///</summary>
		[ImplementPropertyType("firstName")]
		public string FirstName
		{
			get { return this.GetPropertyValue<string>("firstName"); }
		}

		///<summary>
		/// Etternavn
		///</summary>
		[ImplementPropertyType("lastName")]
		public string LastName
		{
			get { return this.GetPropertyValue<string>("lastName"); }
		}

		///<summary>
		/// Is Approved
		///</summary>
		[ImplementPropertyType("umbracoMemberApproved")]
		public bool UmbracoMemberApproved
		{
			get { return this.GetPropertyValue<bool>("umbracoMemberApproved"); }
		}

		///<summary>
		/// Comments
		///</summary>
		[ImplementPropertyType("umbracoMemberComments")]
		public string UmbracoMemberComments
		{
			get { return this.GetPropertyValue<string>("umbracoMemberComments"); }
		}

		///<summary>
		/// Failed Password Attempts
		///</summary>
		[ImplementPropertyType("umbracoMemberFailedPasswordAttempts")]
		public string UmbracoMemberFailedPasswordAttempts
		{
			get { return this.GetPropertyValue<string>("umbracoMemberFailedPasswordAttempts"); }
		}

		///<summary>
		/// Last Lockout Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastLockoutDate")]
		public string UmbracoMemberLastLockoutDate
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastLockoutDate"); }
		}

		///<summary>
		/// Last Login Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastLogin")]
		public string UmbracoMemberLastLogin
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastLogin"); }
		}

		///<summary>
		/// Last Password Change Date
		///</summary>
		[ImplementPropertyType("umbracoMemberLastPasswordChangeDate")]
		public string UmbracoMemberLastPasswordChangeDate
		{
			get { return this.GetPropertyValue<string>("umbracoMemberLastPasswordChangeDate"); }
		}

		///<summary>
		/// Is Locked Out
		///</summary>
		[ImplementPropertyType("umbracoMemberLockedOut")]
		public bool UmbracoMemberLockedOut
		{
			get { return this.GetPropertyValue<bool>("umbracoMemberLockedOut"); }
		}

		///<summary>
		/// Password Answer
		///</summary>
		[ImplementPropertyType("umbracoMemberPasswordRetrievalAnswer")]
		public string UmbracoMemberPasswordRetrievalAnswer
		{
			get { return this.GetPropertyValue<string>("umbracoMemberPasswordRetrievalAnswer"); }
		}

		///<summary>
		/// Password Question
		///</summary>
		[ImplementPropertyType("umbracoMemberPasswordRetrievalQuestion")]
		public string UmbracoMemberPasswordRetrievalQuestion
		{
			get { return this.GetPropertyValue<string>("umbracoMemberPasswordRetrievalQuestion"); }
		}
	}

}

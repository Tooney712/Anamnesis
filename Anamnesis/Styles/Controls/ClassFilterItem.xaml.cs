﻿// Concept Matrix 3.
// Licensed under the MIT license.

namespace Styles.Controls
{
	using System.ComponentModel;
	using System.Windows.Controls;
	using Anamnesis.GameData;
	using Anamnesis.WpfStyles.DependencyProperties;
	using PropertyChanged;

	/// <summary>
	/// Interaction logic for ClassFilterItem.xaml.
	/// </summary>
	[AddINotifyPropertyChangedInterface]
	[SuppressPropertyChangedWarnings]
	public partial class ClassFilterItem : UserControl, INotifyPropertyChanged
	{
		public static DependencyProperty<Classes> ValueDp = Binder.Register<Classes, ClassFilterItem>(nameof(ClassFilterItem.Value), OnValueChanged);
		public static DependencyProperty<Classes> ClassDp = Binder.Register<Classes, ClassFilterItem>(nameof(ClassFilterItem.Class));

		public ClassFilterItem()
		{
			this.InitializeComponent();
			this.ContentArea.DataContext = this;
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		public Classes Value
		{
			get => ValueDp.Get(this);
			set => ValueDp.Set(this, value);
		}

		public Classes Class
		{
			get => ClassDp.Get(this);
			set => ClassDp.Set(this, value);
		}

		public string? ClassName
		{
			get
			{
				return this.Class.GetName();
			}
		}

		public bool IsSelected
		{
			get
			{
				return this.Value.HasFlag(this.Class);
			}

			set
			{
				this.Value = this.Value.SetFlag(this.Class, value);
			}
		}

		public string ImageSource
		{
			get
			{
				return "/Anamnesis;component/Assets/Classes/" + this.Class.ToString() + ".png";
			}
		}

		private static void OnValueChanged(ClassFilterItem sender, Classes value)
		{
			sender.PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(nameof(RoleFilterItem.IsSelected)));
		}
	}
}

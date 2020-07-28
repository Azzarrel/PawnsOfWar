using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Sections.SectionItem;

namespace Sections
{
  /// <summary>
  /// Interaction logic for SectionsView.xaml
  /// </summary>
  public partial class SectionsView : UserControl
  {
    #region Routed commands

    public static readonly RoutedUICommand NavigateToSectionRoutedCommand = new RoutedUICommand(
      "Navigates to section by section ID which is an enum value of the enumeration 'Section'.",
      nameof(SectionsView.NavigateToSectionRoutedCommand),
      typeof(SectionsView));

    #endregion Routed commands

    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
      "ItemsSource",
      typeof(IEnumerable),
      typeof(SectionsView),
      new PropertyMetadata(default(IEnumerable)));

    public IEnumerable ItemsSource
    {
      get => (IEnumerable)GetValue(SectionsView.ItemsSourceProperty);
      set => SetValue(SectionsView.ItemsSourceProperty, value);
    }

    public static readonly DependencyProperty NavigationOffsetProperty = DependencyProperty.Register(
      "NavigationOffset",
      typeof(double),
      typeof(SectionsView),
      new PropertyMetadata(default(double), SectionsView.OnNavigationOffsetChanged));

    public double NavigationOffset
    {
      get => (double)GetValue(SectionsView.NavigationOffsetProperty);
      set => SetValue(SectionsView.NavigationOffsetProperty, value);
    }

    private ScrollViewer Navigator { get; set; }

    public SectionsView()
    {
      InitializeComponent();

      this.Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
      if (TryFindVisualChildElement(this.SectionItemsView, out ScrollViewer scrollViewer))
      {
        this.Navigator = scrollViewer;
      }
    }

    private static void OnNavigationOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      (d as SectionsView).Navigator.ScrollToVerticalOffset((double)e.NewValue);
    }

    private void NavigateToSection_OnExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      SectionItem targetSection = this.SectionItemsView.Items
        .Cast<SectionItem>()
        .FirstOrDefault(section => section.Id == (Section)e.Parameter);
      if (targetSection == null)
      {
        return;
      }

      double verticalOffset = 0;
      if (this.Navigator.CanContentScroll)
      {
        verticalOffset = this.SectionItemsView.Items.IndexOf(targetSection);
      }
      else
      {
        var sectionContainer =
          this.SectionItemsView.ItemContainerGenerator.ContainerFromItem(targetSection) as UIElement;
        Point absoluteContainerPosition = sectionContainer.TransformToAncestor(this.Navigator).Transform(new Point());
        verticalOffset = this.Navigator.VerticalOffset + absoluteContainerPosition.Y;
      }

      var navigationAnimation = this.Resources["NavigationAnimation"] as DoubleAnimation;
      navigationAnimation.From = this.Navigator.VerticalOffset;
      navigationAnimation.To = verticalOffset;
      BeginAnimation(NavigationOffsetProperty, navigationAnimation);
    }

    private void NavigateToSection_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = e.Parameter is Section;
    }

    private bool TryFindVisualChildElement<TChild>(DependencyObject parent, out TChild resultElement)
      where TChild : DependencyObject
    {
      resultElement = null;
      for (var childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(parent); childIndex++)
      {
        DependencyObject childElement = VisualTreeHelper.GetChild(parent, childIndex);

        if (childElement is Popup popup)
        {
          childElement = popup.Child;
        }

        if (childElement is TChild)
        {
          resultElement = childElement as TChild;
          return true;
        }

        if (TryFindVisualChildElement(childElement, out resultElement))
        {
          return true;
        }
      }

      return false;
    }
  }
}

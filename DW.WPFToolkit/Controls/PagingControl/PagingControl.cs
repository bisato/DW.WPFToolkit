using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_Previous", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Next", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ContentPresenter", Type = typeof(ContentControl))]
    [TemplatePart(Name = "PART_PresenterArea", Type = typeof(RectangleGeometry))]
    [TemplatePart(Name = "PART_VisualArea", Type = typeof(Rectangle))]
    public class PagingControl : Selector
    {
        static PagingControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingControl), new FrameworkPropertyMetadata(typeof(PagingControl)));
        }

        public PagingControl()
        {
            ButtonItems = new ObservableCollection<int>();

            SizeChanged += HandleSizeChanged;
        }

        public ObservableCollection<int> ButtonItems
        {
            get { return (ObservableCollection<int>)GetValue(ButtonItemsProperty); }
            set { SetValue(ButtonItemsProperty, value); }
        }

        public static readonly DependencyProperty ButtonItemsProperty =
            DependencyProperty.Register("ButtonItems", typeof(ObservableCollection<int>), typeof(PagingControl), new UIPropertyMetadata(null));

        public bool ShowJumpBar
        {
            get { return (bool)GetValue(ShowJumpBarProperty); }
            set { SetValue(ShowJumpBarProperty, value); }
        }

        public static readonly DependencyProperty ShowJumpBarProperty =
            DependencyProperty.Register("ShowJumpBar", typeof(bool), typeof(PagingControl), new UIPropertyMetadata(true));

        public Dock PreviousBarPosition
        {
            get { return (Dock)GetValue(PreviousBarPositionProperty); }
            set { SetValue(PreviousBarPositionProperty, value); }
        }

        public static readonly DependencyProperty PreviousBarPositionProperty =
            DependencyProperty.Register("PreviousBarPosition", typeof(Dock), typeof(PagingControl), new UIPropertyMetadata(Dock.Left));

        public Dock NextBarPosition
        {
            get { return (Dock)GetValue(NextBarPositionProperty); }
            set { SetValue(NextBarPositionProperty, value); }
        }

        public static readonly DependencyProperty NextBarPositionProperty =
            DependencyProperty.Register("NextBarPosition", typeof(Dock), typeof(PagingControl), new UIPropertyMetadata(Dock.Right));

        public Dock JumpBarPosition
        {
            get { return (Dock)GetValue(JumpBarPositionProperty); }
            set { SetValue(JumpBarPositionProperty, value); }
        }

        public static readonly DependencyProperty JumpBarPositionProperty =
            DependencyProperty.Register("JumpBarPosition", typeof(Dock), typeof(PagingControl), new UIPropertyMetadata(Dock.Top));

        public HorizontalAlignment HorizontalNavigationButtonsAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalNavigationButtonsAlignmentProperty); }
            set { SetValue(HorizontalNavigationButtonsAlignmentProperty, value); }
        }

        public static readonly DependencyProperty HorizontalNavigationButtonsAlignmentProperty =
            DependencyProperty.Register("HorizontalNavigationButtonsAlignment", typeof(HorizontalAlignment), typeof(PagingControl), new UIPropertyMetadata(HorizontalAlignment.Center));

        public VerticalAlignment VerticalNavigationButtonsAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalNavigationButtonsAlignmentProperty); }
            set { SetValue(VerticalNavigationButtonsAlignmentProperty, value); }
        }

        public static readonly DependencyProperty VerticalNavigationButtonsAlignmentProperty =
            DependencyProperty.Register("VerticalNavigationButtonsAlignment", typeof(VerticalAlignment), typeof(PagingControl), new UIPropertyMetadata(VerticalAlignment.Center));

        public bool HasSlideAnimation
        {
            get { return (bool)GetValue(HasSlideAnimationProperty); }
            set { SetValue(HasSlideAnimationProperty, value); }
        }

        public static readonly DependencyProperty HasSlideAnimationProperty =
            DependencyProperty.Register("HasSlideAnimation", typeof(bool), typeof(PagingControl), new UIPropertyMetadata(true));

        public TimeSpan AnimationSpeed
        {
            get { return (TimeSpan)GetValue(AnimationSpeedProperty); }
            set { SetValue(AnimationSpeedProperty, value); }
        }

        public static readonly DependencyProperty AnimationSpeedProperty =
            DependencyProperty.Register("AnimationSpeed", typeof(TimeSpan), typeof(PagingControl), new UIPropertyMetadata(TimeSpan.FromMilliseconds(200)));

        public Orientation AnimationOrientation
        {
            get { return (Orientation)GetValue(AnimationOrientationProperty); }
            set { SetValue(AnimationOrientationProperty, value); }
        }

        public static readonly DependencyProperty AnimationOrientationProperty =
            DependencyProperty.Register("AnimationOrientation", typeof(Orientation), typeof(PagingControl), new UIPropertyMetadata(Orientation.Horizontal));

        public bool LoopItems
        {
            get { return (bool)GetValue(LoopItemsProperty); }
            set { SetValue(LoopItemsProperty, value); }
        }

        public static readonly DependencyProperty LoopItemsProperty =
            DependencyProperty.Register("LoopItems", typeof(bool), typeof(PagingControl), new UIPropertyMetadata(true));

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            ButtonItems.Clear();
            for (int i = 0; i < Items.Count; ++i)
                ButtonItems.Add(i);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PagingItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is PagingItem;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _previousButton = GetTemplateChild("PART_Previous") as Button;
            if (_previousButton != null)
                _previousButton.Click += Previous_Click;

            _nextButton = GetTemplateChild("PART_Next") as Button;
            if (_nextButton != null)
                _nextButton.Click += Next_Click;

            _contentPresenter = GetTemplateChild("PART_ContentPresenter") as ContentControl;
            _visibleClipArea = GetTemplateChild("PART_PresenterArea") as RectangleGeometry;
            _oldContentRectangle = GetTemplateChild("PART_VisualArea") as Rectangle;
            _visibleAreaGrid = GetTemplateChild("PART_MainGrid") as Grid;

            EnableDisableButtons();
        }

        private ContentControl _contentPresenter;
        private RectangleGeometry _visibleClipArea;
        private Rectangle _oldContentRectangle;
        private Grid _visibleAreaGrid;
        private Button _previousButton;
        private Button _nextButton;

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (Items.Count > 0)
            {
                var index = SelectedIndex;
                if (index > 0)
                    SelectedIndex = --index;
                else if (LoopItems)
                    SelectedIndex = Items.Count - 1;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Items.Count > 0)
            {
                var index = SelectedIndex;
                if (index < Items.Count - 1)
                    SelectedIndex = ++index;
                else if (LoopItems)
                    SelectedIndex = 0;
            }
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            EnableDisableButtons();

            if (!CanAnimate(e.RemovedItems, e.AddedItems))
                return;

            RenderAndShowOldContent(e.RemovedItems[0] as FrameworkElement);

            if (AnimateRightToLeft(e.RemovedItems[0], e.AddedItems[0]))
                SwitchDisplayContent(0, GetSizeToMove()*-1, GetSizeToMove(), 0);
            else
                SwitchDisplayContent(0, GetSizeToMove(), GetSizeToMove()*-1, 0);
        }

        private void EnableDisableButtons()
        {
            if (LoopItems)
                return;

            if (_nextButton != null)
                _nextButton.IsEnabled = CanMoveNext();
            if (_previousButton != null)
                _previousButton.IsEnabled = CanMoveBack();
        }

        private bool CanMoveNext()
        {
            return SelectedIndex < Items.Count - 1;
        }

        private bool CanMoveBack()
        {
            return SelectedIndex > 0;
        }

        private bool CanAnimate(IList addedItems, IList removedItems)
        {
            return HasSlideAnimation &&_contentPresenter != null && addedItems.Count > 0 && removedItems.Count > 0;
        }

        private bool AnimateRightToLeft(object removedItem, object addedItem)
        {
            return Items.IndexOf(removedItem) < Items.IndexOf(addedItem);
        }

        private void RenderAndShowOldContent(FrameworkElement frameworkElement)
        {
            if (frameworkElement != null)
            {
                var renderBitmap = RenderContent(frameworkElement);
                _oldContentRectangle.Fill = new ImageBrush(BitmapFrame.Create(renderBitmap));
            }
        }

        private void SwitchDisplayContent(int imageFrom, double imageTo, double contentFrom, int contentTo)
        {
            var fadeNewInStoryboard = new Storyboard();
            Storyboard.SetTargetProperty(fadeNewInStoryboard, GetAnimationAxis());

            var moveImageOutAnimation = new DoubleAnimation(imageFrom, imageTo, new Duration(AnimationSpeed));
            Storyboard.SetTargetName(moveImageOutAnimation, "PART_VisualArea");
            fadeNewInStoryboard.Children.Add(moveImageOutAnimation);

            var moveControlInAnimation = new DoubleAnimation(contentFrom, contentTo, new Duration(AnimationSpeed));
            Storyboard.SetTargetName(moveControlInAnimation, "PART_ContentPresenter");
            fadeNewInStoryboard.Children.Add(moveControlInAnimation);

            _visibleAreaGrid.BeginStoryboard(fadeNewInStoryboard);
        }

        private PropertyPath GetAnimationAxis()
        {
            return AnimationOrientation == Orientation.Horizontal ? new PropertyPath("RenderTransform.(TranslateTransform.X)") : new PropertyPath("RenderTransform.(TranslateTransform.Y)");
        }

        private double GetSizeToMove()
        {
            return AnimationOrientation == Orientation.Horizontal ? _contentPresenter.ActualWidth : _contentPresenter.ActualHeight;
        }

        private static RenderTargetBitmap RenderContent(FrameworkElement element)
        {
            var width = (int)element.ActualWidth;
            var height = (int)element.ActualHeight;
            // TODO: Calculate used dpi
            double dpiX = 96;
            double dpiY = 96;

            var visual = new DrawingVisual();
            var drawingContext = visual.RenderOpen();
            drawingContext.DrawRectangle(new VisualBrush(element), null, new Rect(0, 0, width, height));
            drawingContext.Close();

            var bitmap = new RenderTargetBitmap(width, height, dpiX, dpiY, PixelFormats.Default);

            bitmap.Render(visual);
            return bitmap;
        }

        private void HandleSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _visibleClipArea.Rect = new Rect(0, 0, _contentPresenter.ActualWidth, _contentPresenter.ActualHeight);
        }
    }
}

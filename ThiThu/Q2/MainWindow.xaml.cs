using System.Windows;
using System.Windows.Controls;
using Q2.Models;

namespace Q2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (var context = new PePrn24fallB1Context())
            {
                var query = context.Books.AsQueryable();

                string searchTitle = txtSearchTitle.Text.Trim();
                string searchPublisher = txtSearchPublisher.Text.Trim();

                if (!string.IsNullOrEmpty(searchTitle))
                {
                    query = query.Where(b => b.Title != null && b.Title.Contains(searchTitle));
                }

                if (!string.IsNullOrEmpty(searchPublisher))
                {
                    query = query.Where(b => b.Publisher != null && b.Publisher.Contains(searchPublisher));
                }

                dgBooks.ItemsSource = query.ToList();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBooks.SelectedItem is Book selectedBook)
            {
                txtBookId.Text = selectedBook.BookId.ToString();
                txtTitle.Text = selectedBook.Title;
                txtPublisher.Text = selectedBook.Publisher;
                txtPublicationYear.Text = selectedBook.PublicationYear?.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookId.Text) || !int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please select a book to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string title = txtTitle.Text.Trim();
            string publisher = txtPublisher.Text.Trim();
            string pubYearText = txtPublicationYear.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(publisher) || string.IsNullOrWhiteSpace(pubYearText))
            {
                MessageBox.Show("Title, Publisher, and PublicationYear fields cannot be empty!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(pubYearText, out int publicationYear))
            {
                MessageBox.Show("PublicationYear must be a valid integer!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new PePrn24fallB1Context())
            {
                var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                if (book != null)
                {
                    book.Title = title;
                    book.Publisher = publisher;
                    book.PublicationYear = publicationYear;

                    context.SaveChanges();
                    LoadBooks();
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}

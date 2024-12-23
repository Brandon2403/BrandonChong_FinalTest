﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Linq;
using System.ComponentModel;
using BrandonChong_FinalTest.Model;

namespace BrandonChong_FinalTest
{
    public class PostViewModel : BindableObject
    {
        private readonly PostService _postService;
        private bool _isBusy;
        private string _titleInput;
        private string _bodyInput;

        public ObservableCollection<PostRecord> Posts { get; set; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public string TitleInput
        {
            get => _titleInput;
            set
            {
                _titleInput = value;
                OnPropertyChanged();
            }
        }

        public string BodyInput
        {
            get => _bodyInput;
            set
            {
                _bodyInput = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadPostsCommand { get; }
        public ICommand AddPostCommand { get; }
        public ICommand DeletePostCommand { get; }


        public PostViewModel()
        {
            _postService = new PostService();
            Posts = new ObservableCollection<PostRecord>();

            LoadPostsCommand = new Command(async () => await LoadPosts());
            AddPostCommand = new Command(async () => await AddPost());
            DeletePostCommand = new Command<PostRecord>(async (post) => await DeletePost(post));
        }

        private async Task LoadPosts()
        {
            if (IsBusy) return;

            IsBusy = true;
            Posts.Clear();

            var posts = await _postService.GetPostsAsync();
            foreach (var post in posts)
            {
                Posts.Add(post);
            }

            IsBusy = false;
        }

        private async Task AddPost()
        {
            if (string.IsNullOrWhiteSpace(TitleInput) || string.IsNullOrWhiteSpace(BodyInput))
            {
                // Display a validation message if needed.
                return;
            }

            var newPost = new PostRecord
            {
                UserId = 1, // Example UserId
                Title = TitleInput,
                Body = BodyInput
            };

            var addedPost = await _postService.AddPostAsync(newPost);
            if (addedPost != null)
            {
                Posts.Add(addedPost);

                // Clear input fields after adding the post.
                TitleInput = string.Empty;
                BodyInput = string.Empty;
            }
        }
        private async Task DeletePost(PostRecord post)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to delete this post?", "Yes", "No");
            if (result)
            {
                var success = await _postService.DeletePostAsync(post.Id); // Assuming you have a method to delete the post by ID
                if (success)
                {
                    Posts.Remove(post); // Remove post from the list
                }
            }
        }

    }
}

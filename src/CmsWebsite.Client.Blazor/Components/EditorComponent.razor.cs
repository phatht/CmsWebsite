
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CmsWebsite.Client.Blazor.Components
{
    partial class EditorComponent : IDisposable
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Parameter] public string EditorValue { get; set; }
        [Parameter] public EventCallback<string> EditorValueChanged { get; set; }
        [Parameter] public string EditorHeight { get; set; }
        [Parameter] public string EditorWidth { get; set; }

        string _editorId;
        public string EditorId
        {
            get
            {
                if (string.IsNullOrEmpty(_editorId))
                    _editorId = $"ckeditor_{Guid.NewGuid().ToString().ToLower().Replace("-", "")}";
                return _editorId;
            }
            set => _editorId = value;
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
                await JSRuntime.InvokeVoidAsync("CreateEditor", EditorId, EditorValue, EditorHeight, DotNetObjectReference.Create(this));

            await base.OnAfterRenderAsync(firstRender);
        }


        [JSInvokable]
        public async Task OnEditorChanged(string data)
        {
            await EditorValueChanged.InvokeAsync(data);
        }

        public void Dispose()
        {
            JSRuntime.InvokeVoidAsync("DestroyEditor", EditorId);
        }
    }
}

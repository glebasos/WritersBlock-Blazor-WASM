using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WritersBlock.Models;

namespace WritersBlock.Pages
{
    public partial class Index
    {
        
        public string Text { get; set; } = string.Empty;
        public int Counter { get; set; }
        private ColorModel Color { get; set; } = new();
        Timer Timer { get; set; }

        public Index()
        {
            Counter = 0;
            Timer = new Timer(
                callback: async (_) =>
                {
                    await Count();
                    this.StateHasChanged();
                },
                state: null,
                dueTime: TimeSpan.FromSeconds(0),
                period: TimeSpan.FromSeconds(1));
        }
        
        private void HandleOnChange(ChangeEventArgs args)
        {
            Text = args.Value.ToString();
            Color.SetDefaultValues();
            Counter = 0;
            this.StateHasChanged();
        }

        public async Task Count()
        {
            Counter++;
            Console.WriteLine(Counter);
            Color.RGBValue = Counter * 17;
            Color.Alpha = 1 - Counter * 0.06;
            if (Counter > 15)
            {
                Text = String.Empty;
                Console.WriteLine("хуй");
                Color.SetDefaultValues();
                await JSRuntime.InvokeVoidAsync("copyClipboard");
            }
            Console.WriteLine("rgb = " + Color.RGBValue + " Alpha = " + Color.AlphaString);
        }
    }
}

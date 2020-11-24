$("input[type='image']").click(function () {
    $("input[id='profilePictureUpload']").click();
        });

        $("input[id='profilePictureUpload']").change(function (e) {
            var $this = $(this);
            $this.next().html($this.val().split('\\').pop());
        });
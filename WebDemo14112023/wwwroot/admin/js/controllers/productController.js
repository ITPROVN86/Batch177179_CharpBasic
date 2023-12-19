var news = {
    init: function () {
        news.registerEvents();
    },
    registerEvents: function () {
        // Detail news
        $(document).on('click', '.detail', function () {
            var id = $(this).data('id');
            //@Url.Action("Detail", "Users")
            $.get('/Admin/Products/Detail', { id: id })
                .done(function (response) {
                    if (response.success) {
                        $('#modal-form-detail').modal('show');
                        $('.modal-title').text('Hiển thị thông tin chi tiết sản phẩm');
                        $('#UserNameDetail').text(response.data.userName);
                        $('#FullNameDetail').text(response.data.fullName);
                        $('#RoleDetail').text(response.data.roleId);
                        $('#AddressDetail').text(response.data.address);
                        $('#EmailDetail').text(response.data.email);
                        $('#StatusDetail').text(response.data.status);
                    } else {
                        $('modal-fail').modal('show');
                        //alert(response.message);
                    }
                })
                .fail(function (error) {
                    console.log(error);
                });
        });
        // Save news
        $(document).on('click', '#btn-save', function (event) {
            event.preventDefault();  // Chặn hành động gửi form mặc định
            var form = $('#form-news');
            var data = form.serializeArray();
            // Lấy giá trị từ các trường thuộc tính của news trong form
            // Ví dụ:
            const domEditableElement = document.querySelector('.ck-editor__editable_inline');

            // Get the editor instance from the editable element.
            const editorInstance = domEditableElement.ckeditorInstance;

            // Use the editor instance API.
            //editorInstance.setData(response.data.subjectContent);
            var products = {
                Id: $('#Id').val(),
                UserId: $('#UserId').val(),
                Title: $('#Title').val(),
                Description: $('#Description').val(),
                SubjectContent: editorInstance.getData(),
                Avatar: $('#ImageFile').val(),
                CategoryId: $('#cboNewsCategoryId').val(),
                Price: $('#Price').val(),
                Quanlity: $('#Quanlity').val(),
                DateUpdate: $('#DateUpdate').val(),
                Status: $('#Status').is(':checked') // Lấy giá trị checked của trường Status
            };
            data.push({ name: 'news.Title', value: products.Title });
            data.push({ name: 'news.Description', value: products.Description });
            data.push({ name: 'news.SubjectContent', value: products.SubjectContent });
            data.push({ name: 'news.Avatar', value: products.Avatar });
            data.push({ name: 'news.CategoryId', value: products.CategoryId });
            data.push({ name: 'news.Price', value: products.Price });
            data.push({ name: 'news.Quanlity', value: products.Quanlity });
            data.push({ name: 'news.Status', value: products.Status });
            data.push({ name: 'news.Id', value: products.Id });
            data.push({ name: 'news.UserId', value: products.UserId });
            data.push({ name: 'news.DateUpdate', value: products.DateUpdate });
           
            $.ajax({
                url: $(this).data('action'),
                type: 'POST',
                data: $.param(data),
                success: function (response) {
                    if (response.success) {
                        location.reload();
                    } else {
                        $('#alert-fail').removeClass('hidden');
                        $('#alert-fail').text('Yêu cầu nhập đầy đủ thông tin');
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });
           
        });

        // Edit product
        $(document).on('click', '.edit', function () {
            $('#alert-fail').addClass('hidden');
            var id = $(this).data('id');
            //@Url.Action("Edit", "Users")
            $.get('/Admin/Products/Edit', { id: id })
                .done(function (response) {
                    if (response.success) {
                        $('#modal-form').modal('show');
                        $('.modal-title').text('Chỉnh sửa tin tức');
                        $('#btn-save').attr('data-action', '/Admin/Products/Edit');
                        $('#Id').val(response.data.id);
                        $('#Title').val(response.data.title);
                        $('#Description').val(response.data.description);
                        //$('#SubjectContent').val(response.data.subjectContent);
                        //$('.ck-editor__editable_inline').text(response.data.subjectContent);
                        // A reference to the editor editable element in the DOM.
                        const domEditableElement = document.querySelector('.ck-editor__editable_inline');

                        // Get the editor instance from the editable element.
                        const editorInstance = domEditableElement.ckeditorInstance;

                        // Use the editor instance API.
                        editorInstance.setData(response.data.subjectContent);
                        $('#Title').val(response.data.title);
                        $('#Description').val(response.data.description);
                        $('#ImageFile').val(response.data.avatar);
                        $('#cboProductsCategoryId').val(response.data.categoryId);
                        $('#Price').val(response.data.price);
                        $('#Quanlity').val(response.data.quanlity);
                        $('#DateUpdate').val(response.data.dateUpdate);
                        $('#UserId').val(response.data.userId);
                        $('#preview').attr('src','../Upload/Images/'+ response.data.avatar);
                        $('#Status').prop('checked', response.data.status);
                    } else {
                        alert(response.message);
                    }
                })
                .fail(function (error) {
                    console.log(error);
                });
        });

        $('#uploadButton').click(function () {
            var fileInput = $('#fileInput').get(0);
            var file = fileInput.files[0];

            var formData = new FormData();
            formData.append("file", file);

            $.ajax({
                url: '/Admin/Products/Upload',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    // Xử lý phản hồi từ server (nếu cần)
                    $('#preview').attr('src', '../Upload/Images/' + response.data.avatar);
                    $('#ImageFile').val(response.data.avatar);
                    console.log("Upload thành công");
                },
                error: function (error) {
                    // Xử lý lỗi (nếu có)
                }
            });
        });

        // Delete product
        $(document).on('click', '.delete', function () {
            var id = $(this).data('id');
            $('#delete-id').val(id);
            $('#modal-delete').modal('show');
        });

        // Delete product
        $(document).on('click', '#btn-delete', function () {
            var id = $('#delete-id').val();
            $.post('/Admin/Products/Delete', { userId: id })
                .done(function (response) {
                    if (response.success) {
                        $('#modal-delete').modal('hide');
                        location.reload();
                    } else {
                        alert(response.message);
                    }
                })
                .fail(function (error) {
                    console.log(error);
                });
        });

        // Create User
        $(document).on('click', '.create', function () {
            $('#alert-fail').addClass('hidden');
            $('#modal-form').modal('show');
            $('.modal-title').text('Tạo mới sản phẩm');
            //@Url.Action("Create", "Users")
            $('#btn-save').attr('data-action', '/Admin/Products/Create');
            $('#form-news').trigger('reset');
        });
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();//Nếu sự kiện click đã được click thì
            //gỡ ra và gán sự kiện click khác vào với function truyền event mới gọi AJAX, đầu tiên
            //event sẽ về default như mặc định ban đầu(giống như khi chưa làm gì cả) – tức reset
            //lại(e.preventDefault)
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Products/ChangeStatus",
                data: { id: id },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                        btn.removeClass('btn-default').addClass('btn-danger');
                    }
                    else {
                        btn.text('Khóa');
                        btn.removeClass('btn-danger').addClass('btn-default');
                    }
                }
            });
        });
    }
}
news.init();

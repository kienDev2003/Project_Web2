﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Web2_New.ResetPassword" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <title>Khôi phục mật khẩu</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="./Assets//vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets//fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets//vendor/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="./Assets//vendor/css-hamburgers/hamburgers.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets//vendor/select2/select2.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets//css/util.css">
    <link rel="stylesheet" type="text/css" href="./Assets//css/main.css">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css">
    <link rel="stylesheet" href="https://unpkg.com/boxicons@latest/css/boxicons.min.css">
</head>

<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt">
                    <img src="./Assets/images/fg-img.png" alt="IMG">
                </div>
                <form runat="server" class="login100-form validate-form">
                    <span class="login100-form-title">
                        <b>KHÔI PHỤC MẬT KHẨU</b>
                    </span>
                    <form>
                        <div class="wrap-input100 validate-input"
                            data-validate="Bạn cần nhập đúng thông tin như: ex@abc.xyz">
                            <input runat="server" class="input100" type="text" placeholder="Nhập email"
                                id="txtEmail" value="" />
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class='bx bx-mail-send'></i>
                            </span>
                        </div>
                        <div class="container-login100-form-btn">
                            <input runat="server" id="btnResetPassword" onserverclick="btnResetPassword_Click" type="submit" value="Lấy mật khẩu" />
                        </div>

                        <div class="text-center p-t-12">
                            <a class="txt2" href="./Login.aspx">Trở về đăng nhập
                            </a>
                        </div>
                    </form>
                    <div class="text-center p-t-70 txt2">
                        Quản Lý Điện Thoại <i class="far fa-copyright" aria-hidden="true"></i>
                        <script type="text/javascript">document.write(new Date().getFullYear());</script>
                        <a
                            class="txt2" href="">Vnua </a>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!--===============================================================================================-->
    <script src="./Assets/js/main.js"></script>
    <!--===============================================================================================-->
    <script src="./Assets/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="./Assets/vendor/bootstrap/js/popper.js"></script>
    <!--===============================================================================================-->
    <script src="./Assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="./Assets/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->

</body>
</html>

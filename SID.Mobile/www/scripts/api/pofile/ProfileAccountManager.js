var influenceraccount = new influenceraccountVM();
$.getJSON(apiurl + "/api/Profile/GetProfileAccount/" + InfluencerUserID, function (data) {
    influenceraccount.FullName = data.FullName;
    influenceraccount.FollowerUserCount = data.FollowerUserCount;
    influenceraccount.FollowingUsersCount = data.FollowingUsersCount;
    influenceraccount.ImgPath = data.ImgPath;

    $('.abone').append($('<span>', {
        text: " " + data.FollowerUserCount + " Abone"
    }));

    $('.abonelik').append($('<span>', {
        text: " " + data.FollowingUsersCount + " Abonelikler"
    }));

    $(".profil-name").append(data.FullName);

    $('.p-foto').append($('<img />', {
        src: weburl + data.ImgPath

    }));

});



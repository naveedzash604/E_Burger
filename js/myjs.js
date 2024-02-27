<script type="text/javascript">

        function countdown() {
            seconds = document.getElementById("timerLabel").innerHTML;
            if (seconds > 0) {
                document.getElementById("timerLabel").innerHTML = seconds - 1;
                setTimeout("countdown()", 1000);
            }
        }

        setTimeout("countdown()", 1000);

    </script>
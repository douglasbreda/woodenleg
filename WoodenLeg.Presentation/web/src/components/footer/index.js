import React from "react";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { fab } from "@fortawesome/free-brands-svg-icons";
import "./styles.css";

library.add(fab);

export default function Footer() {
  return (
    <div className="footer-distributed">
      <div class="footer-icons">
        <a href="#">
          <FontAwesomeIcon icon={["fab", "facebook-f"]} />
        </a>
        <a href="#">
          <FontAwesomeIcon icon={["fab", "twitter"]} />
        </a>
        <a href="#">
          <FontAwesomeIcon icon={["fab", "linkedin"]} />
        </a>
        <a href="#">
          <FontAwesomeIcon icon={["fab", "github"]} />
        </a>
      </div>
    </div>
  );
}
